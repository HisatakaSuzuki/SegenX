using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static int Score1,Score2,Score3,Score4,Score5;
	public int total_score; 
	public GameObject[] faceparts = new GameObject[5];
	Face face;
	public bool done = false;

	/*public Material skyboxUp;
	public Material skyboxDown;*/

	// Use this for initialization
	void Start () {
		Score1 = 0;
		Score2 = 0;
		Score3 = 0;
		Score4 = 0;
		Score5 = 0;
		DontDestroyOnLoad (this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		total_score = Score1 + Score2 + Score3 + Score4 + Score5;
		//resultなら
		if (Application.loadedLevel == 2 && !done) {
			XySpawn.suji = total_score;
			faceparts [0] = GameObject.Find ("eye");
			faceparts [1] = GameObject.Find ("hair");
			faceparts [2] = GameObject.Find ("mayu");
			faceparts [3] = GameObject.Find ("mouth");
			faceparts [4] = GameObject.Find ("nose");

			face = faceparts [0].GetComponent<Face> ();

			//ここにif分でカウントすれば量におおじてパーツを決められる
			if (Score1 < 6) {
				faceparts [1].GetComponent<SpriteRenderer> ().sprite = face.m_sprites [4];
			} else if (Score1 >= 6) {
				faceparts [1].GetComponent<SpriteRenderer> ().sprite = face.m_sprites [5];
			} else {
				faceparts [1].GetComponent<SpriteRenderer> ().sprite = null;
			}

			if (Score2 < 2) {
				faceparts [0].GetComponent<SpriteRenderer> ().sprite = face.m_sprites [0];
			} else if (Score2 < 5) {
				faceparts [0].GetComponent<SpriteRenderer> ().sprite = face.m_sprites [1];
			} else if (Score2 < 7) {
				faceparts [0].GetComponent<SpriteRenderer> ().sprite = face.m_sprites [2];
			} else if (Score2 < 10) {
				faceparts [0].GetComponent<SpriteRenderer> ().sprite = face.m_sprites [3];
			} else {
				faceparts [0].GetComponent<SpriteRenderer> ().sprite = null;
			}

			if (Score3 < 5) {
				faceparts [4].GetComponent<SpriteRenderer> ().sprite = face.m_sprites [14];
			} else if (Score3 < 10) {
				faceparts [4].GetComponent<SpriteRenderer> ().sprite = face.m_sprites [15];
			} else if (Score3 < 15) {
				faceparts [4].GetComponent<SpriteRenderer> ().sprite = face.m_sprites [16];
			} else if (Score3 < 22) {
				faceparts [4].GetComponent<SpriteRenderer> ().sprite = face.m_sprites [17];
			} else {
				faceparts [4].GetComponent<SpriteRenderer> ().sprite = null;
			}

			if (Score4 < 7) {
				faceparts [4].GetComponent<SpriteRenderer> ().sprite = face.m_sprites [10];
			} else if (Score4 < 12) {
				faceparts [4].GetComponent<SpriteRenderer> ().sprite = face.m_sprites [11];
			} else if (Score4 < 19) {
				faceparts [4].GetComponent<SpriteRenderer> ().sprite = face.m_sprites [12];
			} else if (Score4 < 28) {
				faceparts [4].GetComponent<SpriteRenderer> ().sprite = face.m_sprites [13];
			} else {
				faceparts [4].GetComponent<SpriteRenderer> ().sprite = null;
			}

			if (Score5 < 2) {
				faceparts [2].GetComponent<SpriteRenderer> ().sprite = face.m_sprites [6];
			} else if (Score5 < 5) {
				faceparts [2].GetComponent<SpriteRenderer> ().sprite = face.m_sprites [7];
			} else if (Score5 < 7) {
				faceparts [2].GetComponent<SpriteRenderer> ().sprite = face.m_sprites [8];
			} else if (Score5 < 10) {
				faceparts [2].GetComponent<SpriteRenderer> ().sprite = face.m_sprites [9];
			} else {
				faceparts [2].GetComponent<SpriteRenderer> ().sprite = null;
			}

			done = true;
		}

		if (Input.GetKeyDown (KeyCode.T)) {
			Application.LoadLevel (2);
		}

		/*if (PlayerController.BranchFrag == false) {
			RenderSettings.skybox = skyboxUp;
		} else {
			RenderSettings.skybox = skyboxDown;
		}*/
	}
}
