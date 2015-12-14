using UnityEngine;
using System.Collections;
using System.IO;

public class DebugCSV : MonoBehaviour {
	StreamWriter sw;
	// Use this for initialization
	void Start () {
		sw = new StreamWriter ("debug.csv");
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = this.gameObject.transform.position;
		try{
			sw.WriteLine(pos.x.ToString() + "," + pos.y.ToString() + "," + pos.z.ToString());
		}catch{
			Debug.Log ("file error");
		}
	}
}
