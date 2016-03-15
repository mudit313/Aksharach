using UnityEngine;
using System.Collections;

public class Letters : MonoBehaviour {
	public GameObject[] Swar;
	public GameObject[] Vyanjan;
	public Object[] Swarob;
	public Object[] Vyanjanob;
	public Transform[] Swarcurr;
	public Transform[] Vyanjancurr;
	public int i,temp;
	// Use this for initialization
	void Start () {
		Swarob = new GameObject[3];
		Vyanjanob = new GameObject[5];
		for (i=0; i<3; i++) {
			temp = Random.Range (0, 12);
			Swarob[i] = Instantiate (Swar[temp],Swarcurr[i].position,Quaternion.identity);
			//Swarcurr[i] = Swar[temp];
		}
		for (i=0; i<5; i++) {
			temp = Random.Range (0, 32);
			Vyanjanob[i] = Instantiate (Vyanjan[temp],Vyanjancurr[i].position,Quaternion.identity);
			//Vyanjancurr[i] = Vyanjan[temp];
		}
	}

	public void OnClick(){
		for (i=0; i<3; i++) {
			Destroy(Swarob[i]);
			//Swarob[i] = null;
		}
		for (i=0; i<5; i++) {
			Destroy(Vyanjanob[i]);
			//Vyanjanob[i] = null;
		}
		for (i=0; i<3; i++) {
			temp = Random.Range (0, 12);
			Swarob[i] = Instantiate (Swar[temp],Swarcurr[i].position,Quaternion.identity);
			//Swarcurr[i] = Swar[temp];
		}
		for (i=0; i<5; i++) {
			temp = Random.Range (0, 32);
			Vyanjanob[i] = Instantiate (Vyanjan[temp],Vyanjancurr[i].position,Quaternion.identity);
			//Vyanjancurr[i] = Vyanjan[temp];
		}
	}

}
