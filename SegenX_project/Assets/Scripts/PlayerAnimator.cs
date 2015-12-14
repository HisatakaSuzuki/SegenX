using UnityEngine;
using System.Collections;

public class PlayerAnimator : MonoBehaviour {

	public static Animator anim;
	public static float speed = 1.5f;
	// Use this for initialization
	void Start () {
		anim = GameObject.Find ("Player").GetComponent<Animator>();
		anim.speed = speed;
		anim.Play("Basic_Run_03");//AnimatorのBasic_Run3を使う

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static void setAnim(string ani){
		anim.Play (ani);
	}

	public static void setSpeed(){
		anim.speed = speed;
	}
}
