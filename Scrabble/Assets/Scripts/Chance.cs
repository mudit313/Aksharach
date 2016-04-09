using UnityEngine;
using System.Collections;

public class Chance : MonoBehaviour {
	public int chance,currsc;
	public GameObject currlet;
	public static GameObject letteronboard;
	public static bool added = true;
	// Use this for initialization
	void Start () {
		chance = 1;
	}
	
	// Update is called once per frame
	void Update () {
		if (!added && letteronboard != null) {
			currsc += letteronboard.GetComponentInChildren<Point> ().pt;
			Debug.Log(currsc);
			added = true;
		}
	}

	public void OnClick(){
		if (chance == 1) {
			chance = 2;
			Score.Score1 += currsc;
		} else {
			chance = 1;
			Score.Score2 += currsc;
		}
		currsc = 0;
	}
}
