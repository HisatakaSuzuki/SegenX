using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class CountManager : MonoBehaviour {

	public Vector3 pointPos;
	public bool canDo=false;
	public int su;
	GameObject[] objs ;
	public ParticleSystem ps;
	public bool canShow=false;
	public MeshRenderer sprend;
	public Button button;
	public Text text;
	public Button button1;
	public Text text1;
	void Start()
	{
		button.image.enabled = false;
		text.enabled = false;
		button1.image.enabled = false;
		text1.enabled = false;
		sprend.enabled = false;
		ps.Stop ();
	}
	void Update()
	{
		if (canDo) 
		{
			objs = GameObject.FindGameObjectsWithTag ("Coin");
			Debug.Log ("olen" + objs.Length);
			for (int i = 0; i < objs.Length; i++)
			{
			//	Debug.Log ("count=" + i);
				objs [i].GetComponent<SO> ().canMove = true;
				ps.Play();

			}
		}
		if (canShow)
		{
			sprend.enabled = true;
			button.image.enabled = true;
			text.enabled = true;
			button1.image.enabled = true;
			text1.enabled = true;
			ps.Stop ();
		}
	}
	public void Restart()
	{
		Application.LoadLevel (1);
	}
	public void Exit()

	{
		Application.Quit ();
	}
}
