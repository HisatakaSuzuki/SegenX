using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour 
{

	[SerializeField,Header("追いかけるターゲットの設定")]
	public GameObject Target;
	[SerializeField,Header("カメラの距離と高さの設定")]
	public int CameraPosY;
	public int CameraPosZ;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		this.transform.position = new Vector3 (Target.transform.position.x, Target.transform.position.y + CameraPosY, Target.transform.position.z + CameraPosZ);
		this.transform.LookAt (Target.transform);
	}
}
