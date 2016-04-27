//C# script that implements the playing rack for the players
//ensures the smooth turn transitions between AI and the player.
//It randomly generates the tiles using equally likely conditions
//for each tile.

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
		
		
		//This loop is used to generate the rack for player 1.
		//It randomly picks 8 tiles from the bank of tiles.
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
		
		//This loop is used to generate the rack for player 2.
		//It randomly picks 8 tiles from the bank of tiles.
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

	//Exchange function exchanges when player is stuck and wants his tiles to be exchanged
	//It causes a penalty of 10 score
	public void exchange(){
		if (Chance.chance == 1) {
			for (i=0; i<8; i++) {
				Destroy (P1curr [i]);
			}
			for (i=0; i<8; i++) {
				temp = Random.Range (0, bankNo);
				P1 [i] = SwarVyanjan [temp];
				P1curr [i] = P1 [i];
				P1curr [i].transform.position = SV [i].position;
				P1curr [i].GetComponent<place> ().initialpos = SV [i].position;
				SwarVyanjan.RemoveAt (temp);
				bankNo--;
			}
			Score.Score1-=10;

		} else {
			for (i=0; i<8; i++) {
				Destroy (P2curr [i]);
			}
			for (i=0; i<8; i++) {
				temp = Random.Range (0, bankNo);
				P2 [i] = SwarVyanjan [temp];
				P2curr [i] = P2 [i];
				P2curr [i].transform.position = SV [i].position;
				P2curr [i].GetComponent<place> ().initialpos = SV [i].position;
				SwarVyanjan.RemoveAt (temp);
				bankNo--;
			}
			Score.Score2-=10;
		}
	}
	
	public void OnClick(){
		
		//checking is play button is pressed.
		if (Chance.accepted)
		{
			
			Debug.Log ("=========>>>>>>> chance change");
			//player 1 ended turn and control is handed to player 2
			if (Chance.chance == 1) {
				
				Debug.Log ("=========>>>>>>> player 2");
				//replenishes the tiles used by the player to play his turn
				//This takes into account an illegal turn and works only if
				//a legal turn is succesfully completed.
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
				//player 2 ended turn and control is handed to player 1
				
				
				//replenishes the tiles used by the player to play his turn
				//This takes into account an illegal turn and works only if
				//a legal turn is succesfully completed.
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
