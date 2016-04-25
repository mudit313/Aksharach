using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

public class Dictionary : MonoBehaviour {
	public class Node
	{
		//public int Index = -1;
		public Dictionary<int, Node> dict = new Dictionary<int, Node>();
	}
	public TextAsset dicfile;
	private string whole;
	private List<string> word;
	public string search;
	public static bool searchmaar = false;
	public List<string> letter;
	static Node temp;
	static Node Root = new Node ();
	
	// Use this for initialization
	void Start () {
		whole = dicfile.text;
		
		word = new List<string> ();
		word.AddRange (whole.Split ("\n" [0]));
		int words = word.Count;
		
		for (int j = 0; j < words; j++) {
			letter = new List<string> ();
			letter.AddRange (word [j].Split (" " [0]));
			temp = Root;
			int c;
			for (int i = 0; i < letter.Count; i++) {
				bool f = int.TryParse (letter [i], out c);
				//Debug.Log (c);
				if (!temp.dict.ContainsKey (c)) {
					Node n = new Node ();
					temp.dict.Add (c, n);
				}
				temp = temp.dict [c];
			}
			if (!temp.dict.ContainsKey (0)) {
				Node x = new Node ();
				temp.dict.Add (0, x);
				//Debug.Log(j);
			}
		}
	}
	
	public static int Search(List<int> query){
		int flag = 0;
		//Debug.Log ("X");
		//Debug.Log("searching");
		//query = AI.possible;
		//query = new List<int> ();
		/*query.Add (2325);
		query.Add (2369);
		query.Add (2335);
		query.Add (2344);
		query.Add (2346);
		query.Add (2341);*/
		temp = Root;
		for (int i = 0; i<query.Count; i++) {
			if (temp.dict.ContainsKey (query [i])) {
				if ((i == query.Count - 1) && temp.dict[query [i]].dict.ContainsKey(0)){
					//Debug.Log ("Machaya");
					flag = 1;
				}
				else if((i == query.Count - 1) && !temp.dict[query [i]].dict.ContainsKey(0)){
					//Debug.Log ("Adha Machaya");
					flag = 0;
				}
				else {
					//Debug.Log ("X");
					temp = temp.dict [query [i]];
					//Debug.Log(query[i]);
					flag = 0;
				}
			} else {
				//Debug.Log ("Nahi Machaya");
				//Debug.Log (query [i]);
				break;
			}
		}
		//2309 2325 2341 2344 2368 2351
		//2325 2369 2335 2344 2346 2344
		/*int k = int.Parse(letter[4]);
		Debug.Log (k);*/
		return flag;
	}
}

