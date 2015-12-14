using UnityEngine;
using System.Collections;

public class RotateXY : MonoBehaviour {

	public bool canMove=false;
	float timeout=0;
	float timeCount=50;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (Random.Range(1,90)* Time.deltaTime, Random.Range(1,90)* Time.deltaTime, Random.Range(1,90)* Time.deltaTime);
		if (canMove) 
		{
			
			timeout += Time.deltaTime;
			this.transform.position = Vector3.Lerp (this.transform.position, GameObject.Find ("countManger").GetComponent<CountManager> ().pointPos, timeout / timeCount);
		}
	}
	public void Button()
	{
		Application.LoadLevel (1);
	}
	public void HowToPlay()
	{
		Application.LoadLevel (3);
	}

}
