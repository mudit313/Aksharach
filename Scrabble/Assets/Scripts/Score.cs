using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {
	public static int Score1,Score2;
	public Text s1,s2;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		s1.text = Score1.ToString ();
		s2.text = Score2.ToString ();
	}
}
