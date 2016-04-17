using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class AI : MonoBehaviour {
	public static List<int> possible = new List<int> ();
	public static string words;
	public List<string> wor;
	public GameObject Dict;
	public List<int> searchmaar;
	public static List<int> per;
	//public byte[] t = new byte[8];
	public string t;
	public int x,f, c = 0;
	// Use this for initialization

	public void printlist(List<int> pr, int n){
		for (int i=0; i<n; i++) {
			c = c + 1;
			//Debug.Log (c);
			Debug.Log (pr[i]);
		}
	}

	void permute(List<int> per, int n, int l,bool d){
		int temp;
		if (l != n) {
			for (int i = l; i<n; i++) {
				temp = per [l];
				per [l] = per [i];
				per [i] = temp;
				permute (per, n, l + 1, d);
				permute (per, n, l + 1, false);
				temp = per [l];
				per [l] = per [i];
				per [i] = temp;
			}
		} else {
			if (d){
				Dict.GetComponent<Dictionary>().Search(per);
				//Dictionary.query = per;
				//Dictionary.searchmaar = true;
				//printlist (per, n);
			}
		}
	}


	/*void delete(List<int> x){
		x.RemoveAt (3);
	}*/

	void Update() {
		if(Letters.rack){
			words = Letters.Swarob [0].GetComponentInChildren<Point> ().Unicode + " " + Letters.Swarob [1].GetComponentInChildren<Point> ().Unicode + " " + Letters.Swarob [2].GetComponentInChildren<Point> ().Unicode;
			words = words + " " + Letters.Vyanjanob [0].GetComponentInChildren<Point> ().Unicode + " " + Letters.Vyanjanob [1].GetComponentInChildren<Point> ().Unicode + " " + Letters.Vyanjanob [2].GetComponentInChildren<Point> ().Unicode + " " + Letters.Vyanjanob [3].GetComponentInChildren<Point> ().Unicode + " " + Letters.Vyanjanob [4].GetComponentInChildren<Point> ().Unicode;
			Letters.rack = false;
			wor = new List<string> ();
			possible = new List<int> ();
			wor.AddRange (words.Split (" " [0]));
			for(int i = 0 ;i<wor.Count;i++){
				possible.Add (int.Parse (wor[i]));
			}

			for(int i=1;i<possible.Count;i++){
				if(possible[i-1] == 2309 && possible[i] == 2306)
					possible.RemoveAt(i-1);
				if(possible[i-1] == 2309 && possible[i] == 2307)
					possible.RemoveAt(i-1);
			}

		for (int j = 0; j<256; j++) {
				searchmaar = new List<int>();
				x = j;
				f = 1;
				for (int i=0; i<8; i++) {
				//Debug.Log (x % 2);
					if(x%2 == 1)
					{
						searchmaar.Add (possible[i]);
					}
					f = f * 2;
					x = x / f;
				}
				permute(searchmaar,searchmaar.Count,0,true);
			}
		}
	}
}
