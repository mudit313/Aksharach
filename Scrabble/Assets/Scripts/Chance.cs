using UnityEngine;
using System.Collections;

public class Chance : MonoBehaviour {
	public int chance,currsc;
	// Use this for initialization
	void Start () {
		chance = 1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnClick(){
		if (chance == 1) {
			chance = 2;
			Score.Score1 += currsc;
		} else {
			chance = 1;
			Score.Score2 += currsc;
		}
	}
}
