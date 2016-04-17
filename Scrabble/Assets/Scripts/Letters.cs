using UnityEngine;
using System.Collections;

public class Letters : MonoBehaviour {
	public GameObject[] Swar;
	public GameObject[] Vyanjan;
	public static GameObject[] Swarob = new GameObject[3];
	public static GameObject[] Vyanjanob = new GameObject[5];
	public Transform[] Swarcurr;
	public Transform[] Vyanjancurr;
	public int i,temp;
	public static bool rack = false;
	// Use this for initialization
	void Start () {
		for (i=0; i<3; i++) {
			temp = Random.Range (0, 12);
			Swarob[i] = GameObject.Instantiate (Swar[temp],Swarcurr[i].position,Quaternion.identity) as GameObject;
			//Swarcurr[i] = Swar[temp];
		}
		for (i=0; i<5; i++) {
			temp = Random.Range (0, 30);
			Vyanjanob[i] = GameObject.Instantiate (Vyanjan[temp],Vyanjancurr[i].position,Quaternion.identity) as GameObject;
			//Vyanjancurr[i] = Vyanjan[temp];
		}
		rack = true;
	}

	public void OnClick(){
		if (Chance.accepted) {
			for (i=0; i<3; i++) {
				Destroy (Swarob [i]);
				//Swarob[i] = null;
			}
			for (i=0; i<5; i++) {
				Destroy (Vyanjanob [i]);
				//Vyanjanob[i] = null;
			}
			for (i=0; i<3; i++) {
				temp = Random.Range (0, 12);
				Swarob[i] = GameObject.Instantiate (Swar[temp],Swarcurr[i].position,Quaternion.identity) as GameObject;
				//Swarcurr[i] = Swar[temp];
			}
			for (i=0; i<5; i++) {
				temp = Random.Range (0, 30);
				Vyanjanob[i] = GameObject.Instantiate (Vyanjan[temp],Vyanjancurr[i].position,Quaternion.identity) as GameObject;
				//Vyanjancurr[i] = Vyanjan[temp];
			}
		}
	}
}
