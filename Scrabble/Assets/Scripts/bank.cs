using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class bank : MonoBehaviour {
	
	
	public List<GameObject> SwarVyanjan=new List<GameObject>();
	
	public GameObject[] P1curr;
	public GameObject[] P2curr;
	
	public Transform[] SV;
	
	public int i,temp,turn=0,bankNo=177;
	
	// Use this for initialization
	void Start () {
		P1curr = new GameObject[8];
		P2curr = new GameObject[8];
		
		
		
		for (i=0; i<8; i++) {
			temp = Random.Range (0, bankNo);
			P1curr[i] =SwarVyanjan[temp];
			P1curr[i].transform.position=SV[i].position;
			//CMC said to put initial pos too
			//P1curr[i].GetComponent<place>().i
			SwarVyanjan.RemoveAt(temp);
			bankNo--;
			//P1curr[i] =(GameObject) Instantiate (SwarVyanjan[temp],SV[i].position,Quaternion.identity);
		}
		
		for (i=0; i<8; i++) {
			temp = Random.Range (0, bankNo);
			P2curr[i] =SwarVyanjan[temp];
			P2curr[i].transform.position=SV[i].position;
			SwarVyanjan.RemoveAt(temp);
			bankNo--;
			//P2curr[i] =(GameObject) Instantiate (SwarVyanjan[temp],SV[i].position,Quaternion.identity);
		}
		
		
	}
	
	public void OnClick(){
		
		if (Chance.accepted){
			
			if (turn % 2 == 0) {
				
				for (i=0; i<8; i++) {
					
					if(P1curr[i].GetComponent<place>().onboard==true)
					{
						temp = Random.Range (0, bankNo);
						P1curr[i] =SwarVyanjan[temp];
						P1curr[i].transform.position=SV[i].position;
						SwarVyanjan.RemoveAt(temp);
						bankNo--;
					}
					P1curr [i].SetActive (true);
				}
				
				for (i=0; i<8; i++) {
					
					if(P2curr[i].GetComponent<place>().onboard==true)
					{
						temp = Random.Range (0, bankNo);
						P2curr[i] =SwarVyanjan[temp];
						P2curr[i].transform.position=SV[i].position;
						SwarVyanjan.RemoveAt(temp);
						bankNo--;
					}
					P2curr [i].SetActive (false);
				}
				
			} else {
				
				for (i=0; i<8; i++) {
					if(P1curr[i].GetComponent<place>().onboard==true)
					{
						temp = Random.Range (0, bankNo);
						P1curr[i] =SwarVyanjan[temp];
						P1curr[i].transform.position=SV[i].position;
						SwarVyanjan.RemoveAt(temp);
						bankNo--;
					}
					P1curr [i].SetActive (false);
				}
				
				for (i=0; i<8; i++) {
					if(P2curr[i].GetComponent<place>().onboard==true)
					{
						temp = Random.Range (0, bankNo);
						P2curr[i] =SwarVyanjan[temp];
						P2curr[i].transform.position=SV[i].position;
						SwarVyanjan.RemoveAt(temp);
						bankNo--;
					}
					P2curr [i].SetActive (true);
				}
			}
			turn++;
			
		}
		
		
	}
}
