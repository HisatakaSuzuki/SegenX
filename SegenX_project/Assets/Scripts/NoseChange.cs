using UnityEngine;
using System.Collections;

public class NoseChange : MonoBehaviour {
	Face face;
	SpriteRenderer spRend;
	// Use this for initialization
	void Start () {
		face = GetComponent<Face> ();
		spRend = GetComponent<SpriteRenderer> ();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.O)) 
		{
			spRend.sprite = face.m_sprites [Random.Range (14, 17)];
		}
	}
}
