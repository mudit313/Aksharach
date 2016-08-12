using UnityEngine;
using System.Collections;

public class AIfalse : MonoBehaviour {


	public GameObject AIkiller;
	// Use this for initialization
	void Start () {
		if ((PlayerPrefs.GetInt ("GameMode")) == 1) {
			AIkiller.GetComponent<AI> ().enabled = false;
			Debug.Log ("killed AI :P");
		}

		if ((PlayerPrefs.GetInt ("GameMode")) == 0) {
			Debug.Log("@#@#@#@");
			Debug.Log(PlayerPrefs.GetInt ("Level"));
			Debug.Log("@#@#@#@");
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
