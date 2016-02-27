using UnityEngine;
using System.Collections;

public class Letters : MonoBehaviour {
	public GameObject[] Swar;
	public GameObject[] Vyanjan;
	public Transform[] Swarcurr;
	public Transform[] Vyanjancurr;
	private int i,temp;
	// Use this for initialization
	void Start () {
		for (i=0; i<3; i++) {
			temp = Random.Range (0, 11);
			Instantiate (Swar[temp],Swarcurr[i].position,Quaternion.identity);
			//Swarcurr[i] = Swar[temp];
		}
		for (i=0; i<5; i++) {
			temp = Random.Range (0, 10);
			Instantiate (Vyanjan[temp],Vyanjancurr[i].position,Quaternion.identity);
			//Vyanjancurr[i] = Vyanjan[temp];
		}
	}
}
