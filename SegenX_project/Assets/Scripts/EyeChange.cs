using UnityEngine;
using System.Collections;

public class EyeChange : MonoBehaviour {

	Face face;
	SpriteRenderer spRend;
	// Use this for initialization
	void Start () {
		face = GetComponent<Face> ();
		spRend = GetComponent<SpriteRenderer> ();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Y)) 
		{
			spRend.sprite = face.m_sprites [Random.Range (0,3)];
		}
	}
}
