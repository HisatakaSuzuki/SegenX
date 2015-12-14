using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	//private float Timer;
	private bool JumpFrag = false;
	private bool SpeedFrag = false;

	private AudioSource sound01;
	private AudioSource sound02;
	private AudioSource sound03;

	public static bool BranchFrag = false;

	//[SerializeField,Header("プレイヤーの移動スピードの設定")]
	public static float Speed;

	//[SerializeField,Header("プレイヤーのジャンプ力の設定")]
	public static int JumpForce;

	[SerializeField,Header("横方向の移動")]
	public float Xmove;

	// Use this for initialization
	void Start () 
	{
		//Timer = 0;
		Speed = 0.12f;
		JumpForce = 5;

		//AudioSourceコンポーネントを取得し、変数に格納
		AudioSource[] audioSources = GetComponents<AudioSource>();
		sound01 = audioSources[0];
		sound02 = audioSources[1];
		sound03 = audioSources[2];
	}
	
	// Update is called once per frame
	/*void Update () 
	{
		Timer = Time.deltaTime * Speed;
		this.transform.position = new Vector3 (transform.position.x + Xmove, transform.position.y, transform.position.z + Timer);

		//ジャンプ判定
		if (Input.GetMouseButtonDown (0) && JumpFrag) {
			this.GetComponent<Rigidbody>().velocity = Vector3.up * JumpForce;
			PlayerAnimator.setAnim ("Jump");
			JumpFrag = false;
		}
		//Debug.Log (JumpFrag);
	}*/

	void FixedUpdate()
	{
		//Timer = Time.deltaTime * Speed;
		this.transform.position = new Vector3 (transform.position.x + Xmove, transform.position.y, transform.position.z + Speed);

		//ジャンプ判定
		//if (Input.GetMouseButtonDown (0) && JumpFrag) {
		if (Input.GetKeyDown(KeyCode.Space) && JumpFrag) {
			this.GetComponent<Rigidbody>().velocity = Vector3.up * JumpForce;
			PlayerAnimator.setAnim ("Jump");
			sound01.PlayOneShot(sound01.clip);
			JumpFrag = false;
		}
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Ground") {
			PlayerAnimator.setAnim ("Basic_Run_03");
			JumpFrag = true;
			if (!SpeedFrag) {
				Speed = 0.12f;
			}
		}
	}

	/*void OnCollisionExit(Collision collision){
		if (collision.gameObject.tag == "Ground" && JumpFrag) {
			PlayerAnimator.setAnim ("Fall");
		}
	}*/
		
	void OnTriggerEnter(Collider collider)
	{
		//分岐ポイントの挙動
		if (collider.gameObject.tag == "Branch") {
			if (!BranchFrag) {
				//Xmove += Time.deltaTime * Speed;
				Xmove += Speed;
				this.transform.rotation = Quaternion.Euler (0, 45, 0);
			} else {
				//Xmove -= Time.deltaTime * Speed;
				Xmove -= Speed;
				this.transform.rotation = Quaternion.Euler (0, -45, 0);
			}
		}

		//まっすぐに進む
		if (collider.gameObject.tag == "Straight") {
			Xmove = 0;
			this.transform.rotation = Quaternion.Euler (0,-9,0);
		}

		//道に戻る
		if (collider.gameObject.tag == "L_Branch") {
			//Xmove += Time.deltaTime * Speed;
			Xmove += Speed;
			this.transform.rotation = Quaternion.Euler (0, 45, 0);
		}

		//道に戻る
		if (collider.gameObject.tag == "R_Branch") {
			//Xmove -= Time.deltaTime * Speed;
			Xmove -= Speed;
			this.transform.rotation = Quaternion.Euler (0, -45, 0);
			Debug.Log ("r");
		}

		//アイテムをとった時の挙動
		if (collider.gameObject.tag == "Coin") {
			BranchFrag = !BranchFrag;
			switch (collider.gameObject.GetComponent<Item>().GetID()) {
			case 1:
				GameManager.Score1++;
				break;
			case 2:
				GameManager.Score2++;
				break;
			case 3:
				GameManager.Score3++;
				break;
			case 4:
				GameManager.Score4++;
				break;
			case 5:
				GameManager.Score5++;
				break;
			default:
				break;
			}
			Destroy (collider.transform.parent.gameObject);
		}

		//落下時
		if (collider.gameObject.tag == "End") {
			Application.LoadLevel (2);
		}

		//落ちるポイントでの挙動
		if (collider.gameObject.tag == "Fall"/* && JumpFrag*/) {
			//FallFrag = true;
			PlayerAnimator.setAnim ("Fall");
			sound02.PlayOneShot(sound02.clip);
			Speed = 0.0f;
			//this.transform.position = new Vector3 (transform.position.x + Xmove, transform.position.y, transform.position.z);

			//PlayerAnimator.anim.SetBool ("fall", true);
		} /*else {
			Speed = 5;
			PlayerAnimator.anim.SetBool ("fall",false);
		}*/

		//上に戻る挙動
		if (collider.gameObject.tag == "JumpUp") {
			PlayerAnimator.setAnim ("Jump");
			this.GetComponent<Rigidbody>().velocity = Vector3.up * JumpForce * 3;
			sound03.PlayOneShot(sound03.clip);
			JumpFrag = true;
		}

		//スピードアップアイテムをとった挙動
		if (collider.gameObject.tag == "SpeedUp") {
			StartCoroutine ("SpeedUpper");
			Destroy (collider.gameObject);
		}

		//ゴール判定
		if (collider.gameObject.tag == "Goal") {
			Application.LoadLevel (2);
		}
	}

	public IEnumerator SpeedUpper(){
		if (SpeedFrag == false) {
			SpeedFrag = true;
			Speed = Speed * 2;
			PlayerAnimator.speed = 3.0f;
			PlayerAnimator.setSpeed ();
			yield return new WaitForSeconds (2.2f);
			Speed = 0.12f;
			PlayerAnimator.speed = 1.5f;
			PlayerAnimator.setSpeed ();
			SpeedFrag = false;
		}
	}
}
