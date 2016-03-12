using UnityEngine;
using System.Collections;

public class Chance : MonoBehaviour {
	public int chance,currsc;
	public GameObject currlet;
	// Use this for initialization
	void Start () {
		chance = 1;
	}
	
	// Update is called once per frame
	void Update () {
		currlet = place.letteronboard;
		if (place.y && currlet != null) {
			//currsc = 5;
			currsc = currlet.GetComponentInChildren<Point> ().pt;
			Debug.Log(currsc);
		}
		else
			currsc = 0;
	}

	public void OnClick(){
		if (chance == 1) {
			chance = 2;
			Score.Score1 += currsc;
			place.y = false;
		} else {
			chance = 1;
			Score.Score2 += currsc;
			place.y = false;
		}
	}
}
