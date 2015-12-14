using UnityEngine;
using System.Collections;

public class MouthChange : MonoBehaviour {
	Face face;
	SpriteRenderer spRend;
	// Use this for initialization
	void Start () {
		face = GetComponent<Face> ();
		spRend = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.P)) 
		{
			spRend.sprite = face.m_sprites [Random.Range (10, 13)];
		}
	}
}
