using UnityEngine;
using System.Collections;

public class Chance : MonoBehaviour {
	public int chance,currsc;
	public Vector3 diff;
	public static GameObject xletter;
	public static GameObject letteronboard;
	public static bool added = true;
	// Use this for initialization
	void Start () {
		chance = 1;
	}
	
	// Update is called once per frame
	void Update () {
		if (!added && letteronboard != null) {
		//if (letteronboard != null) {
			//Debug.Log("Hi");
			if(xletter != null)
			{
				//Debug.Log(xletter.name);
				diff = letteronboard.transform.position - xletter.transform.position;
				if(((0.49 < diff.x) && (diff.x < 0.5)) || ((-0.5 < diff.x) && (diff.x < -0.49)) || ((-0.5 < diff.y) && (diff.y < -0.49)) || ((0.49 < diff.y ) && (diff.y < 0.5))){
					currsc += letteronboard.GetComponentInChildren<Point> ().pt;
					added = true;
					Debug.Log(currsc);
					//Debug.Log("Hi");
				}
			}
			else{
				currsc += letteronboard.GetComponentInChildren<Point> ().pt;
				added = true;
				Debug.Log(currsc);
			}
		}
		if (added && letteronboard != null && xletter != null) {
			//Debug.Log("Hi");
			diff = letteronboard.transform.position - xletter.transform.position;
			if(((0.49 < diff.x) && (diff.x < 0.5)) || ((-0.5 < diff.x) && (diff.x < -0.49)) || ((-0.5 < diff.y) && (diff.y < -0.49)) || ((0.49 < diff.y ) && (diff.y < 0.5))){}
			else{
				currsc -= letteronboard.GetComponentInChildren<Point> ().pt;
				added = false;
				Debug.Log(currsc);
				//Debug.Log("Hi");
			}
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
