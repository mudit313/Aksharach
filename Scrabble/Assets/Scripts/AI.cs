using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class AI : MonoBehaviour {
	public static List<int> possible = new List<int> ();
	public static string words;
	public List<string> wor;
	public Transform plachere;
	public List<int> searchmaar;
	public static List<int> per;
	public int valid;
	public List<GameObject> Onrack = new List<GameObject>();
	public string t;
	public int x, c = 0;
	//public List<List<int>> poswords;
	public List<int> placethis = new List<int> ();
	// Use this for initialization

	public void printlist(List<int> pr, int n){
		for (int i=0; i<n; i++) {
			c = c + 1;
			Debug.Log (pr[i]);
		}
		Debug.Log ("");
	}

	public int scorecal(List<int> pr){
		int poi = 0;
		for (int j = 0; j<pr.Count; j++) {
			for (int i = 0; i<Onrack.Count; i++) {
				if(Onrack[i].GetComponentInChildren<Point> ().Unicode != "2309 2306" && Onrack[i].GetComponentInChildren<Point> ().Unicode != "2309 2307"){
					if(pr[j] == int.Parse(Onrack[i].GetComponentInChildren<Point> ().Unicode)){
						poi += Onrack[i].GetComponentInChildren<Point> ().pt;
						break;
					}
				}
				else if(Onrack[i].GetComponentInChildren<Point> ().Unicode == "2309 2306"){
					if(pr[j] == 2306){
						poi += 4;
						break;
					}
				}
				else if(Onrack[i].GetComponentInChildren<Point> ().Unicode == "2309 2307"){
					if(pr[j] == 2307){
						poi += 8;
						break;
					}
				}
			}
		}
		return poi;
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
				valid = Dictionary.Search(per);
				if(valid == 1){
					int p = scorecal(per);
					per.Add(p);
					printlist(per,per.Count);
					if(placethis[placethis.Count-1] < p){
						placethis.Clear();
					//Debug.Log(placethis[placethis.Count-1] + " < " + p);
						//placethis = per;
						for(int i=0;i<per.Count;i++){
							placethis.Add (per[i]);
						}
					}
				}
				//Dictionary.query = per;
				//Dictionary.searchmaar = true;
				//printlist (per, n);
			}
		}
	}

	void placekar(List<int> placekrna){
		int blocks = 0;
		for (int i=0; i<placekrna.Count-1; i++) {
			for(int j = 0; j<Onrack.Count; j++){
				if(Onrack[j].GetComponentInChildren<Point> ().Unicode != "2309 2306" && Onrack[j].GetComponentInChildren<Point> ().Unicode != "2309 2307"){
					if(placekrna[i] == int.Parse(Onrack[j].GetComponentInChildren<Point> ().Unicode)){
						if(placekrna[i]<2325 && i!=0){
							blocks--;
						}
						Onrack[j].transform.position = new Vector3(plachere.position.x + (blocks * (2 * Board.sizeTile)), plachere.position.y, 0);
						blocks++;
						Onrack.RemoveAt(j);
						break;
					}
				}
				else if(Onrack[j].GetComponentInChildren<Point> ().Unicode == "2309 2306"){
					if(placekrna[i] == 2306){
						if(i!=0)
							blocks--;
						Onrack[j].transform.position = new Vector3(plachere.position.x + (blocks * (2 * Board.sizeTile)), plachere.position.y, 0);
						blocks++;
						Onrack.RemoveAt(j);
						break;
					}
				}
				else if(Onrack[j].GetComponentInChildren<Point> ().Unicode == "2309 2307"){
					if(placekrna[i] == 2307){
						if(i!=0)
							blocks--;
						Onrack[j].transform.position = new Vector3(plachere.position.x + (blocks * (2 * Board.sizeTile)), plachere.position.y, 0);
						blocks++;
						Onrack.RemoveAt(j);
						break;
					}
				}
			}
		}
	}

	/*void Start(){
		placethis.Add (0);
	}*/
	
	void Update() {
		if(Chance.chance == 2){
			placethis.Clear();
			placethis.Add (0);
			possible = new List<int> ();
			Onrack = new List<GameObject>();
			//poswords = new List<List<int>> ();
			for(int i=0;i<8;i++){
				Onrack.Add (bank.P2curr[i]);
			}
			words = "5";
			for(int i=0;i<8;i++){
				words = words + " " + Onrack[i].GetComponentInChildren<Point>().Unicode;
				Debug.Log(words);
			}
			wor = new List<string> ();
			possible = new List<int> ();
			wor.AddRange (words.Split (" " [0]));
			for(int i = 1 ;i<wor.Count;i++){
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
				for (int i=0; i<8; i++) {
				//Debug.Log (x % 2);
					if(x%2 == 1)
					{
						searchmaar.Add (possible[i]);
					}
					x = x / 2;
				}
				permute(searchmaar,searchmaar.Count,0,true);
			}
			//placethis = best (poswords);
			Debug.Log("This should go on board");
			printlist(placethis,placethis.Count);
			placekar(placethis);
			//poswords.Clear();
			/*List<int> p = new List<int>();
			p.Add (2327);
			p.Add (2325);
			//p.Add (2305);
			//p.Add (2335);
			//p.Add (2344);
			//p.Add (2360);
			Dict.GetComponent<Dictionary>().Search(p);*/
			//2331 2366 2305 2335 2344 2366
			//Debug.Log (poswords.Count);
			Chance.chance = 1;
		}
	}
}
