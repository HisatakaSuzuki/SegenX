using UnityEngine;
using System.Collections;

public class SO : MonoBehaviour {

	public bool canMove=false;
	public float timeout=0;
	public float timeCount=50;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		//transform.Rotate (Random.Range(1,90)* Time.deltaTime, Random.Range(1,90)* Time.deltaTime, Random.Range(1,90)* Time.deltaTime);
		if (canMove) 
		{

			timeout += Time.deltaTime;
			this.transform.position = Vector3.Lerp (this.transform.position, GameObject.Find ("countManger").GetComponent<CountManager> ().pointPos, timeout / timeCount);

		}
		if (timeout>4.0f) 
		{
			canMove = false;
			timeout = 0.0f;
			Debug.Log ("ok");
			Destroy (this.gameObject, 3.0f);
			GameObject.Find ("countManger").GetComponent<CountManager> ().canShow=true;
		}

	}


}
