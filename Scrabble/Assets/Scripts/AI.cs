﻿using UnityEngine;
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
	public List<int> anchored;
	public int x, c = 0;
	//public List<List<int>> poswords;
	public List<int> placethis = new List<int> ();
	// Use this for initialization

	public void printlist(List<int> pr, int n){
		for (int i=0; i<n; i++) {
			c = c + 1;
			Debug.Log (pr[i]);
		}
		//Debug.Log ("");
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

	void permute(List<int> per, int n, int l,bool d, List<int> toadd, int x, int y, int z){
		int temp;
		if (l != n) {
			for (int i = l; i<n; i++) {
				temp = per [l];
				per [l] = per [i];
				per [i] = temp;
				permute (per, n, l + 1, d, toadd,x,y,z);
				permute (per, n, l + 1, false, toadd,x,y,z);
				temp = per [l];
				per [l] = per [i];
				per [i] = temp;
			}
		} else {
			if (d){
				List<int> tosearch = new List<int>(toadd);
				for(int i=0;i<per.Count;i++){
					tosearch.Add (per[i]);
				}
				valid = Dictionary.Search(tosearch);
				if(valid == 1){
					int p = scorecal(per);
					for(int i=1;i<=z;i++){
						p += Board.matrix[x-z,y];
					}
					tosearch.Add(p);
					per.Add(p);
					printlist(tosearch,tosearch.Count);
					if(placethis[placethis.Count-1] < p){
						placethis.Clear();
						for(int i=0;i<per.Count;i++){
							placethis.Add (per[i]);
						}
						plachere.transform.position = new Vector3(plachere.position.x + (x * (2 * Board.sizeTile)), plachere.position.y - (y * (2 * Board.sizeTile)), 0);
					}
					//printlist(tosearch,tosearch.Count);
				}
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
	
	void anchoring(string[,] board){
		//int ct = 0;
		for (int i=0; i<16; i++) {
			for (int j=0;j<16;j++){
				if(int.Parse(board[i,j]) > 1000 && board[i+1,j] == "0"){
					//ct++;
					board[i+1,j] = "1";
				}
			}
		}
		//Debug.Log (ct);
	}

	void Update() {
		if(Chance.chance == 2){
			placethis.Clear();
			placethis.Add (0);
			anchored = new List<int> ();
			possible = new List<int> ();
			Onrack = new List<GameObject>();
			//poswords = new List<List<int>> ();
			for(int i=0;i<8;i++){
				Onrack.Add (bank.P2curr[i]);
			}
			words = "5";
			for(int i=0;i<8;i++){
				words = words + " " + Onrack[i].GetComponentInChildren<Point>().Unicode;
				//Debug.Log(words);
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

			anchoring(Board.unicode);
			for(int l =0 ;l<16;l++){
				for(int k=0;k<16;k++){
					if(Board.unicode[l,k] == "1"){
						//anchored.Clear();
						for(int m=1;m<4;m++){
							//Debug.Log(Board.unicode[l-m,k]);
							if(int.Parse (Board.unicode[l-m,k]) > 1000){
								anchored.Insert (0,int.Parse (Board.unicode[l-m,k]));
								//Debug.Log("Anchored");
								//printlist(anchored,anchored.Count);
								for (int j = 1; j<256; j++) {
									searchmaar = new List<int>();
									x = j;
									for (int i=0; i<8; i++) {
										if(x%2 == 1)
										{
											searchmaar.Add (possible[i]);
										}
										x = x / 2;
									}
									if(searchmaar.Count < 5)
										permute(searchmaar,searchmaar.Count,0,true,anchored,l,k,m);
								}
							}
							else
								break;
						}
					}
				}
			}
			//Debug.Log("This should go on board");
			//printlist(placethis,placethis.Count);
			placekar(placethis);
			Chance.chance = 1;
		}
	}
}
