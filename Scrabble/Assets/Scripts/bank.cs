using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class bank : MonoBehaviour {
	
	
	public List<GameObject> SwarVyanjan=new List<GameObject>();
	
	public GameObject[] P1curr;
	public static GameObject[] P2curr;

	public GameObject[] P1;
	public GameObject[] P2;
	public Transform[] SV;
	
	public int i,temp=0,bankNo=179;
	public static bool done = false;
	
	// Use this for initialization
	void Start () {
		P1curr = new GameObject[8];
		P2curr = new GameObject[8];
		P1 = new GameObject[8];
		P2 = new GameObject[8];
		
		
		
		for (i=0; i<8; i++) {
			temp = Random.Range (0, bankNo);
			P1[i] =SwarVyanjan[temp];
			P1curr[i]=P1[i];
			P1curr[i].transform.position=SV[i].position;
			P1curr[i].GetComponent<place>().initialpos=SV[i].position;
			SwarVyanjan.RemoveAt(temp);
			bankNo--;
			//P1curr[i] =(GameObject) Instantiate (SwarVyanjan[temp],SV[i].position,Quaternion.identity);
		}

		Debug.Log ("=========>>>>>>> p1 rack made");
		
		for (i=0; i<8; i++) {
			temp = Random.Range (0, bankNo);
			P2[i] =SwarVyanjan[temp];
			P2curr[i]=P2[i];
			P2curr[i].transform.position=SV[i].position;
			P2curr[i].GetComponent<place>().initialpos=SV[i].position;
			SwarVyanjan.RemoveAt(temp);
			bankNo--;
			//P2curr[i] =(GameObject) Instantiate (SwarVyanjan[temp],SV[i].position,Quaternion.identity);
			P2curr[i].SetActive (false);
		}

		Debug.Log ("=========>>>>>>> p2 rack made");

		
		
	}
	
	public void OnClick(){
		
		if (Chance.accepted)
		{

			Debug.Log ("=========>>>>>>> chance change");
			
			if (Chance.chance == 1) {

				Debug.Log ("=========>>>>>>> player 2");
				
				for (i=0; i<8; i++) {
					
					if(P1curr[i].GetComponent<place>().onboard==true)
					{
						temp = Random.Range (0, bankNo);
						P1curr[i] =SwarVyanjan[temp];
						P1curr[i].transform.position=SV[i].position;
						P1curr[i].GetComponent<place>().initialpos=SV[i].position;
						SwarVyanjan.RemoveAt(temp);
						bankNo--;
					}
					P1curr [i].SetActive (true);
					P1curr[i]=P1[i];
				}
				
				for (i=0; i<8; i++) {
					
					if(P2curr[i].GetComponent<place>().onboard==true)
					{
						temp = Random.Range (0, bankNo);
						P2curr[i] =SwarVyanjan[temp];
						P2curr[i].transform.position=SV[i].position;
						P2curr[i].GetComponent<place>().initialpos=SV[i].position;
						SwarVyanjan.RemoveAt(temp);
						bankNo--;
					}
					P2[i]=P2curr[i];
					P2curr [i].SetActive (false);
				}
				
			} else {
				
				for (i=0; i<8; i++) {
					if(P1curr[i].GetComponent<place>().onboard==true)
					{
						temp = Random.Range (0, bankNo);
						P1curr[i] =SwarVyanjan[temp];
						P1curr[i].transform.position=SV[i].position;
						P1curr[i].GetComponent<place>().initialpos=SV[i].position;
						SwarVyanjan.RemoveAt(temp);
						bankNo--;
					}
					P1[i]=P1curr[i];
					P1curr [i].SetActive (false);
				}
				
				for (i=0; i<8; i++) {
					if(P2curr[i].GetComponent<place>().onboard==true)
					{
						temp = Random.Range (0, bankNo);
						P2curr[i] =SwarVyanjan[temp];
						P2curr[i].transform.position=SV[i].position;
						P2curr[i].GetComponent<place>().initialpos=SV[i].position;
						SwarVyanjan.RemoveAt(temp);
						bankNo--;
					}
					P2curr [i].SetActive (true);
					P2curr[i]=P2[i];
				}
			}
			Chance.accepted=false;
			
		}
		
		
	}
}
