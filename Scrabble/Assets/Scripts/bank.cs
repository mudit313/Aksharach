using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class bank : MonoBehaviour {
    
    //public GameObject[] SwarVyanjan;
	public List<GameObject> SwarVyanjan=new List<GameObject>();
    
	public GameObject[] P1curr;
	public GameObject[] P2curr;
    
    public Transform[] SV;
    
	
	
	public int i,temp,turn=0;
	// Use this for initialization
	void Start () {
		P1curr = new GameObject[8];
		P2curr = new GameObject[8];
        
        
        
		for (i=0; i<8; i++) {
			temp = Random.Range (0, 44);
			//P1curr[i] =(GameObject) Instantiate (SwarVyanjan[temp],SV[i].position,Quaternion.identity);
		}
        
        for (i=0; i<8; i++) {
			temp = Random.Range (0, 44);
			//P2curr[i] =(GameObject) Instantiate (SwarVyanjan[temp],SV[i].position,Quaternion.identity);
		}
		
        
	}

	public void OnClick(){

        if (Chance.accepted){
        
		if (turn % 2 == 0) {

			for (i=0; i<8; i++) {
				P1curr [i].SetActive (true);
			}

			for (i=0; i<8; i++) {
				P2curr [i].SetActive (false);
			}
		
		} else {
		
			for (i=0; i<8; i++) {
				P1curr [i].SetActive (false);
			}
			
			for (i=0; i<8; i++) {
				P2curr [i].SetActive (true);
			}
		}
        turn++;
	

            
            
            
        }
		 {
			for (i=0; i<3; i++) {
			//	Destroy (Swarob [i]);
				//Swarob[i] = null;
			}
			for (i=0; i<5; i++) {
			//	Destroy (Vyanjanob [i]);
				//Vyanjanob[i] = null;
			}
			for (i=0; i<3; i++) {
			//	temp = Random.Range (0, 12);
			//	Swarob [i] = Instantiate (Swar [temp], Swarcurr [i].position, Quaternion.identity);
				//Swarcurr[i] = Swar[temp];
			}
			for (i=0; i<5; i++) {
			//	temp = Random.Range (0, 32);
			//	Vyanjanob [i] = Instantiate (Vyanjan [temp], Vyanjancurr [i].position, Quaternion.identity);
				//Vyanjancurr[i] = Vyanjan[temp];
			}
		}
	}
}
