using UnityEngine;
using System.Collections;

public class XySpawn : MonoBehaviour {
	public GameObject Xy;
	float num=-1;
	float high=0;
	float highPlus=0;
	float mtimes=0;
	bool canUse=true;
	float count=0;
	bool canMove=false;
	float timeout=0;
	float timeCount=50;
	public Vector3 DOPoint;
	public static int suji=0;
	GameObject[] instance;
	// Use this for initialization
	void Start () {
		instance = new GameObject[suji];
	}
	
	// Update is called once per frame
	void Update () {
		if(canUse)
		{
			mtimes++;
			if (num != -1 && num != 1 && num != 0 && num % 25 == 0) {
				highPlus++;
				high = -2 * highPlus;
				num = -1;
			}
			if (mtimes % 3 == 0) {
				count++;
				num++;
				Instantiate (Xy, new Vector3 (transform.position.x + 1 * num, transform.position.y + high, transform.position.z), Quaternion.identity);
			}
	//		Debug.Log (mtimes);
		}
		if (count >= suji)
		{
			canUse = false;
			GameObject.Find ("countManger").GetComponent<CountManager> ().su=suji;
			GameObject.Find("countManger").GetComponent<CountManager>().canDo=true;
		}

	}
}
