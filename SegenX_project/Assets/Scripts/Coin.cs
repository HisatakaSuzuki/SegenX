using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

	public bool P_Branch = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		PlayerController.BranchFrag = P_Branch;
	}
}
