using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class AI : MonoBehaviour {
	public static List<int> possible = new List<int> ();
	public static string words;
	public List<string> wor;
	public Transform plachere,templachere;
	public Vector3 tempos;
	public List<int> searchmaar;
	public static List<int> per;
	public Dictionary<int,int> matra = new Dictionary<int, int>();
	public int valid;
	public List<GameObject> Onrack;// = new List<GameObject>();
	public List<GameObject> Onbrd = new List<GameObject>();
	public string t;
	public GameObject Chancescript,bankscript;
	public List<int> anchored;
	public int anx,any;
	public int uni,faltu;
	public int lt,rt,up,dn;
	public int x, c = 0;
	public int placedir = 0;
	public List<List<int>> listlist;
	public List<int> placethis = new List<int> ();
	public GameObject tempvyan;
	// Use this for initialization

	public void printlist(List<int> pr, int n){
		for (int i=0; i<n; i++) {
			c = c + 1;
			Debug.Log (pr[i]);
		}
	}

	public void printmatrix(string[,] board){
		string row;
		for (int i=0; i<16; i++) {
			row = "";
			for(int j=0;j<16;j++){
				row += board[i,j];
			}
			Debug.Log(row);
		}
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

	void permute(List<int> per, int n, int l,bool d, List<int> toadd, int x, int y, int z, int dir){
		int temp;
		if (l != n) {
			for (int i = l; i<n; i++) {
				temp = per [l];
				per [l] = per [i];
				per [i] = temp;
				permute (per, n, l + 1, d, toadd,x,y,z,dir);
				permute (per, n, l + 1, false, toadd,x,y,z,dir);
				temp = per [l];
				per [l] = per [i];
				per [i] = temp;
			}
		} else {
			if (d){
				List<int> tosearch = new List<int>();
				if(dir == 1 || dir == 3){
					tosearch = new List<int>(toadd);
					for(int i=0;i<per.Count;i++){
						if(per[i] < 2325 && per[i] >= 2310)
							tosearch.Add (per[i] + 56);
						else if(per[i] == 2309)
							tosearch.Add (2381);
						else
							tosearch.Add (per[i]);
					}
				}
				else if(dir == 2 || dir == 4){
					tosearch = new List<int>();
					for(int i=0;i<per.Count;i++){
						if(per[i] < 2325 && per[i] >= 2310)
							tosearch.Add (per[i] + 56);
						else if(per[i] == 2309)
							tosearch.Add (2381);
						else
							tosearch.Add (per[i]);
					}
					for(int i=0;i<toadd.Count;i++){
						tosearch.Add (toadd[i]);
					}
				}
				valid = Dictionary.Search(tosearch);
				for(int i=1;i<tosearch.Count;i++){
					if(tosearch[i-1]>=2366 && tosearch[i]<2325)
						valid = 0;
				}
				if(valid == 1){
					if(dir == 1 || dir == 2){
						up = y;
						dn = y;
						if(dir == 1){
							lt = x - toadd.Count;
							rt = x;
							for(int i=1;i<per.Count;i++){
								if(per[i]>2324){
									rt++;
								}
							}
						}
						else if(dir == 2){
							rt = x + toadd.Count;
							lt = x;
							for(int i=1;i<per.Count;i++){
								if(per[i]>2324){
									lt--;
								}
							}
						}
					}
					else if(dir == 3 || dir == 4)
					{
						lt = x;
						rt = x;
						if(dir == 3){
							up = y - toadd.Count;
							dn = y;
							for(int i=1;i<per.Count;i++){
								if(per[i]>2324){
									dn++;
								}
							}
						}
						else if(dir == 4){
							dn = y + toadd.Count;
							up = y;
							for(int i=1;i<per.Count;i++){
								if(per[i]>2324){
									up--;
								}
							}
						}
					}
					int p = scorecal(per);
					if(dir == 1){
						for(int i=1;i<=z;i++){
							p += Board.matrix[x-i,y]*Board.multiples[x-i,y];
						}
						for (int i=1; i<=z; i++)
						{
							p*=Board.powers[x-i,y];
						}
					}
					else if(dir == 2){
						for(int i=1;i<=z;i++){
							p += Board.matrix[x+i,y]*Board.multiples[x+i,y];
						}
						for (int i=1; i<=z; i++)
						{
								p*=Board.powers[x+i,y];
						}
					}
					else if(dir == 3){
						for(int i=1;i<=z;i++){
							p += Board.matrix[x,y-i]*Board.multiples[x,y-i];
						}
						for (int i=1; i<=z; i++)
						{
							p*=Board.powers[x,y-i];
						}
					}
					else if(dir == 4){
						for(int i=1;i<=z;i++){
							p += Board.matrix[x,y+i]*Board.multiples[x,y+i];
						}
						for (int i=1; i<=z; i++)
						{
							p*=Board.powers[x,y+i];
						}
					}
					int s = p;
					double f = Penalty.penalty(lt,rt,up,dn);
					p -= (int)f;
					tosearch.Add(s);
					per.Add(s);
					tosearch.Add(p);
					per.Add(p);
					List<int> templist = new List<int>();
					templist.Clear();
					printlist(tosearch,tosearch.Count);
					for(int i=0;i<per.Count;i++){
						templist.Add (per[i]);
					}
					templist.Add(x);
					templist.Add(y);
					templist.Add(dir);
					//printlist(templist,templist.Count);
					if(!((dir == 1 || dir == 3) && per[0]<2325))
						listlist.Add(templist);
				}
			}
		}
	}

	void placekar(List<int> placekrna, int dir){
		int blocks = 0;
		Onbrd.Clear ();
		for (int i=0; i<placekrna.Count-4; i++) {
			for(int j = 0; j<Onrack.Count; j++){
				if(Onrack[j].GetComponentInChildren<Point> ().Unicode != "2309 2306" && Onrack[j].GetComponentInChildren<Point> ().Unicode != "2309 2307"){
					if(placekrna[i] == int.Parse(Onrack[j].GetComponentInChildren<Point> ().Unicode)){
						if(placekrna[i]<2325 && i != 0){
							blocks--;
						}
						if(dir == 1 || dir == 2){
							if(placekrna[i]>=2325){
								Onrack[j].transform.position = new Vector3(templachere.position.x + (blocks * (2 * Board.sizeTile)), templachere.position.y, 0);
								Onrack[j].GetComponent<place>().onboard = true;
								Onrack[j].GetComponent<place>().placed = true;
								Board.unicode[anx + blocks,any] = Onrack[j].GetComponentInChildren<Point>().Unicode;
								Board.matrix[anx + blocks,any] = Onrack[j].GetComponentInChildren<Point>().pt;
								Debug.Log(Board.unicode[anx + blocks,any]);
							}
							else{
								Onrack[j].GetComponent<place>().onboard = true;
								Onrack[j].GetComponent<place>().placed = true;
								//Onrack[j].transform.position = new Vector3(0,0,-5);
								uni = int.Parse(Onrack[j].GetComponentInChildren<Point>().Unicode);
								uni = (uni % 100) - 6;
								tempos = new Vector3(templachere.position.x + (blocks * (2 * Board.sizeTile)), templachere.position.y, 0);
								Board.matrix[anx + blocks,any] += Onrack[j].GetComponentInChildren<Point>().pt;
								if(Onbrd.Count != 0){
									tempvyan = GameObject.Instantiate(Onbrd[Onbrd.Count-1].GetComponent<intersection>().arr[uni],tempos,Quaternion.identity) as GameObject;
									Onbrd[Onbrd.Count-1].transform.position = new Vector3(100,100,5);
									Board.unicode[anx + blocks,any] = tempvyan.GetComponentInChildren<Point>().Unicode;
									Debug.Log(Board.unicode[anx + blocks,any]);
									Onrack[j].transform.position = new Vector3(100,120,5);
								}else
									Onrack[j].transform.position = tempos;
							}
						}
						else if(dir == 3 || dir == 4){
							if(placekrna[i]>=2325){
								Onrack[j].transform.position = new Vector3(templachere.position.x, templachere.position.y - (blocks * (2 * Board.sizeTile)), 0);
								Onrack[j].GetComponent<place>().placed = true;
								Onrack[j].GetComponent<place>().onboard = true;
								Board.unicode[anx,any+blocks] = Onrack[j].GetComponentInChildren<Point>().Unicode;
								Board.matrix[anx,any + blocks] = Onrack[j].GetComponentInChildren<Point>().pt;
								Debug.Log(Board.unicode[anx,any + blocks]);
							}
							else{
								Onrack[j].GetComponent<place>().onboard = true;
								Onrack[j].GetComponent<place>().placed = true;
								//Onrack[j].transform.position = new Vector3(0,0,-5);
								uni = int.Parse(Onrack[j].GetComponentInChildren<Point>().Unicode);
								uni = (uni % 100) - 6;
								tempos = new Vector3(templachere.position.x, templachere.position.y - (blocks * (2 * Board.sizeTile)), 0);
								Board.matrix[anx,any + blocks] += Onrack[j].GetComponentInChildren<Point>().pt;
								if(Onbrd.Count != 0){
									tempvyan = GameObject.Instantiate(Onbrd[Onbrd.Count-1].GetComponent<intersection>().arr[uni],tempos,Quaternion.identity) as GameObject;
									Onbrd[Onbrd.Count-1].transform.position = new Vector3(100,100,5);
									Board.unicode[anx,any + blocks] = tempvyan.GetComponentInChildren<Point>().Unicode;
									Debug.Log(Board.unicode[anx,any + blocks]);
									Onrack[j].transform.position = new Vector3(100,120,5);
								}else
									Onrack[j].transform.position = tempos;
							}
						}
						blocks++;
						Onbrd.Add(Onrack[j]);
						Onrack.RemoveAt(j);
						break;
					}
				}
				else if(Onrack[j].GetComponentInChildren<Point> ().Unicode == "2309 2306"){
					if(placekrna[i] == 2306){
						if(i!=0)
							blocks--;
						if(dir == 1 || dir == 2){
							Onrack[j].GetComponent<place>().onboard = true;
							Onrack[j].GetComponent<place>().placed = true;
							//Onrack[j].transform.position = new Vector3(0,0,-5);
							uni = 2306;
							uni = (uni % 100) - 6;
							tempos = new Vector3(templachere.position.x + (blocks * (2 * Board.sizeTile)), templachere.position.y, 0);
							Board.matrix[anx + blocks,any] += Onrack[j].GetComponentInChildren<Point>().pt;
							if(Onbrd.Count != 0){
								tempvyan = GameObject.Instantiate(Onbrd[Onbrd.Count-1].GetComponent<intersection>().arr[uni],tempos,Quaternion.identity) as GameObject;
								Onbrd[Onbrd.Count-1].transform.position = new Vector3(100,100,5);
								Board.unicode[anx + blocks,any] = tempvyan.GetComponentInChildren<Point>().Unicode;
								Debug.Log(Board.unicode[anx + blocks,any]);
								Onrack[j].transform.position = new Vector3(100,120,5);
							}else
								Onrack[j].transform.position = tempos;
						}
						else if(dir == 3 || dir == 4){
							Onrack[j].GetComponent<place>().onboard = true;
							Onrack[j].GetComponent<place>().placed = true;
							//Onrack[j].transform.position = new Vector3(0,0,-5);
							uni = 2306;
							uni = (uni % 100) - 6;
							tempos = new Vector3(templachere.position.x, templachere.position.y - (blocks * (2 * Board.sizeTile)), 0);
							Board.matrix[anx,any + blocks] += Onrack[j].GetComponentInChildren<Point>().pt;
							if(Onbrd.Count != 0){
								tempvyan = GameObject.Instantiate(Onbrd[Onbrd.Count-1].GetComponent<intersection>().arr[uni],tempos,Quaternion.identity) as GameObject;
								Onbrd[Onbrd.Count-1].transform.position = new Vector3(100,100,5);
								Board.unicode[anx,any + blocks] = tempvyan.GetComponentInChildren<Point>().Unicode;
								Debug.Log(Board.unicode[anx,any + blocks]);
								Onrack[j].transform.position = new Vector3(100,120,5);
							}else
								Onrack[j].transform.position = tempos;
						}
						blocks++;
						Onrack.RemoveAt(j);
						break;
					}
				}
				else if(Onrack[j].GetComponentInChildren<Point> ().Unicode == "2309 2307"){
					if(placekrna[i] == 2307){
						if(i!=0)
							blocks--;
						if(dir == 1 || dir == 2){
							Onrack[j].GetComponent<place>().onboard = true;
							Onrack[j].GetComponent<place>().placed = true;
							//Onrack[j].transform.position = new Vector3(0,0,-5);
							uni = 2307;
							uni = (uni % 100) - 6;
							tempos = new Vector3(templachere.position.x + (blocks * (2 * Board.sizeTile)), templachere.position.y, 0);
							Board.matrix[anx + blocks,any] += Onrack[j].GetComponentInChildren<Point>().pt;
							if(Onbrd.Count != 0){
								tempvyan = GameObject.Instantiate(Onbrd[Onbrd.Count-1].GetComponent<intersection>().arr[uni],tempos,Quaternion.identity) as GameObject;
								Onbrd[Onbrd.Count-1].transform.position = new Vector3(100,100,5);
								Board.unicode[anx + blocks,any] = tempvyan.GetComponentInChildren<Point>().Unicode;
								Debug.Log(Board.unicode[anx + blocks,any]);
								Onrack[j].transform.position = new Vector3(100,120,5);
							}else
								Onrack[j].transform.position = tempos;
						}
						else if(dir == 3 || dir == 4){
							Onrack[j].GetComponent<place>().onboard = true;
							Onrack[j].GetComponent<place>().placed = true;
							//Onrack[j].transform.position = new Vector3(0,0,-5);
							uni = 2307;
							uni = (uni % 100) - 6;
							tempos = new Vector3(templachere.position.x, templachere.position.y - (blocks * (2 * Board.sizeTile)), 0);
							Board.matrix[anx,any + blocks] += Onrack[j].GetComponentInChildren<Point>().pt;
							if(Onbrd.Count != 0){
								tempvyan = GameObject.Instantiate(Onbrd[Onbrd.Count-1].GetComponent<intersection>().arr[uni],tempos,Quaternion.identity) as GameObject;
								Onbrd[Onbrd.Count-1].transform.position = new Vector3(100,100,5);
								Board.unicode[anx,any + blocks] = tempvyan.GetComponentInChildren<Point>().Unicode;
								Debug.Log(Board.unicode[anx,any + blocks]);
								Onrack[j].transform.position = new Vector3(100,120,5);
							}else
								Onrack[j].transform.position = tempos;
						}
						blocks++;
						Onrack.RemoveAt(j);
						break;
					}
				}
			}
		}
	}
	
	void anchoringright(string[,] board){
		for (int i=0; i<15; i++) {
			for (int j=0;j<16;j++){
				if(int.TryParse(board[i,j], out faltu) && int.TryParse(board[i+1,j], out faltu)){
					if(int.Parse(board[i,j]) > 1000 && int.Parse(board[i+1,j]) < 1000){
						board[i+1,j] = "1";
					}
				}
				else{
					if(int.TryParse(board[i+1,j], out faltu)){
						if(int.Parse(board[i+1,j]) < 1000)
							board[i+1,j] = "1";
					}
				}
			}
		}
	}

	void anchoringleft(string[,] board){
		for (int i=1; i<16; i++) {
			for (int j=0;j<16;j++){
				if(int.TryParse(board[i,j], out faltu) && int.TryParse(board[i-1,j], out faltu)){
					if(int.Parse(board[i,j]) > 1000 && int.Parse(board[i-1,j]) < 1000){
						board[i-1,j] = "2";
					}
				}
				else{
					if(int.TryParse(board[i-1,j], out faltu)){
						if(int.Parse(board[i-1,j]) < 1000)
							board[i-1,j] = "2";
					}
				}
			}
		}
	}

	void anchoringdown(string[,] board){
		for (int i=0; i<16; i++) {
			for (int j=0;j<15;j++){
				if(int.TryParse(board[i,j], out faltu) && int.TryParse(board[i,j+1], out faltu)){
					if(int.Parse(board[i,j]) > 1000 && int.Parse(board[i,j+1]) < 1000){
						board[i,j+1] = "3";
					}
				}
				else{
					if(int.TryParse(board[i,j+1], out faltu)){
						if(int.Parse(board[i,j+1]) < 1000)
							board[i,j+1] = "3";
					}
				}
			}
		}
	}

	void anchoringup(string[,] board){
		for (int i=0; i<16; i++) {
			for (int j=1;j<16;j++){
				if(int.TryParse(board[i,j], out faltu) && int.TryParse(board[i,j-1], out faltu)){
					if(int.Parse(board[i,j]) > 1000 && int.Parse(board[i,j-1]) < 1000){
						board[i,j-1] = "4";
					}
				}
				else{
					if(int.TryParse(board[i,j-1], out faltu)){
						if(int.Parse(board[i,j-1]) < 1000)
							board[i,j-1] = "4";
					}
				}
			}
		}
	}

	List<int> choose(List<List<int>> all){
		List<int> ret = all[0];
		for (int i = 1; i<all.Count; i++) {
			if(all[i][all[i].Count-4] > ret[ret.Count-4]){
				ret = all[i];
			}
		}
		return ret;
	}

	void Update() {
		if(Chance.chance == 2){
			listlist = new List<List<int>> ();
			templachere.position = plachere.position;
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

			//printmatrix(Board.unicode);

			anchoringright(Board.unicode);
			for(int l =0 ;l<16;l++){
				for(int k=0;k<16;k++){
					if(Board.unicode[l,k] == "1"){
						anchored.Clear();
						for(int m=1;m<4;m++){
							if(int.TryParse(Board.unicode[l-m,k],out faltu)){
								if(int.Parse (Board.unicode[l-m,k]) > 1000){
									anchored.Insert (0,int.Parse (Board.unicode[l-m,k]));
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
											permute(searchmaar,searchmaar.Count,0,true,anchored,l,k,m,1);
									}
								}
								else
									break;
							}
							else{
								anchored.Add (int.Parse (Board.unicode[l-m,k].Split(" "[0])[0]));
								anchored.Add (int.Parse (Board.unicode[l-m,k].Split(" "[0])[1]));
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
										permute(searchmaar,searchmaar.Count,0,true,anchored,l,k,m,1);
								}
							}
						}
					}
				}
			}
			
			anchoringleft(Board.unicode);
			for(int l =0 ;l<16;l++){
				for(int k=0;k<16;k++){
					if(Board.unicode[l,k] == "2"){
						anchored.Clear();
						for(int m=1;m<4;m++){
							if(int.TryParse(Board.unicode[l+m,k],out faltu)){
								if(int.Parse (Board.unicode[l+m,k]) > 1000){
									anchored.Add (int.Parse (Board.unicode[l+m,k]));
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
											permute(searchmaar,searchmaar.Count,0,true,anchored,l,k,m,2);
									}
								}
								else
									break;
							}
							else{
								anchored.Add (int.Parse (Board.unicode[l+m,k].Split(" "[0])[0]));
								anchored.Add (int.Parse (Board.unicode[l+m,k].Split(" "[0])[1]));
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
										permute(searchmaar,searchmaar.Count,0,true,anchored,l,k,m,2);
								}
							}
						}
					}
				}
			}

			anchoringdown(Board.unicode);
			for(int l =0 ;l<16;l++){
				for(int k=0;k<16;k++){
					if(Board.unicode[l,k] == "3"){
						anchored.Clear();
						for(int m=1;m<4;m++){
							if(int.TryParse(Board.unicode[l,k-m], out faltu)){
								if(int.Parse (Board.unicode[l,k-m]) > 1000){
									anchored.Add (int.Parse (Board.unicode[l,k-m]));
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
											permute(searchmaar,searchmaar.Count,0,true,anchored,l,k,m,3);
									}
								}
								else
									break;
							}
							else{
								anchored.Add (int.Parse (Board.unicode[l,k-m].Split(" "[0])[0]));
								anchored.Add (int.Parse (Board.unicode[l,k-m].Split(" "[0])[1]));
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
										permute(searchmaar,searchmaar.Count,0,true,anchored,l,k,m,3);
								}
							}
						}
					}
				}
			}/**/

			anchoringup(Board.unicode);
			for(int l =0 ;l<16;l++){
				for(int k=1;k<16;k++){
					if(Board.unicode[l,k] == "4"){
						anchored.Clear();
						for(int m=1;m<4;m++){
							//Debug.Log(Board.unicode[l-m,k]);
							if(int.TryParse(Board.unicode[l,k+m], out faltu)){
								if(int.Parse (Board.unicode[l,k+m]) > 1000){
									anchored.Add (int.Parse (Board.unicode[l,k+m]));
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
											permute(searchmaar,searchmaar.Count,0,true,anchored,l,k,m,4);
									}
								}
								else
									break;
							}
							else{
								anchored.Add (int.Parse (Board.unicode[l,k+m].Split(" "[0])[0]));
								anchored.Add (int.Parse (Board.unicode[l,k+m].Split(" "[0])[1]));
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
										permute(searchmaar,searchmaar.Count,0,true,anchored,l,k,m,4);
								}
							}
						}
					}
				}
			}

			if(listlist.Count != 0){
				placethis = choose(listlist);
				/*placethis.Add (2354);
				placethis.Add (2310);
				placethis.Add (2349);
				placethis.Add (2);
				placethis.Add (10);
				placethis.Add (4);
				placethis.Add (5);
				placethis.Add (4);*/
				anx = placethis[placethis.Count-3];
				any = placethis[placethis.Count-2];
				placedir = placethis[placethis.Count-1];
				Debug.Log(anx + " " + any + " " + placedir);
				if(placedir == 2){
					for(int i=1;i<placethis.Count-5;i++){
						if(placethis[i] < 2325 && placethis[i] > 1000)
							anx++;
					}
				}
				if(placedir == 4){
					for(int i=1;i<placethis.Count-5;i++){
						if(placethis[i] < 2325 && placethis[i] > 1000)
							any++;
					}
				}

				Debug.Log(anx + " " + any + " " + placedir);

				templachere.transform.position = new Vector3(plachere.position.x + (anx * (2 * Board.sizeTile)), plachere.position.y - (any * (2 * Board.sizeTile)), 0);
				if(placedir == 2){
					templachere.position = new Vector3(templachere.position.x - ((placethis.Count-6) * (2 * Board.sizeTile)),templachere.position.y,0);
				}
				else if(placedir == 4){
					templachere.position = new Vector3(templachere.position.x,templachere.position.y + ((placethis.Count-6) * (2 * Board.sizeTile)),0);
				}
				printlist(placethis, placethis.Count);
				placekar(placethis,placedir);
				Score.Score2 += placethis[placethis.Count-5];
			}
			Chance.accepted = true;
			Chancescript.GetComponent<Chance>().OnClick();
			bankscript.GetComponent<bank>().OnClick();
		}
	}
}
