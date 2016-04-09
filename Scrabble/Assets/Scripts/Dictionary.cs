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
	public List<string> letter;
	public List<int> query;
	
	// Use this for initialization
	void Start () {
		whole = dicfile.text;
		
		word = new List<string>();
		word.AddRange(whole.Split("\n"[0]) );
		int words = word.Count;
		Node temp;

		Node Root = new Node();
		for (int j = 0; j < words; j++) {
			letter = new List<string> ();
			letter.AddRange(word [j].Split(" "[0]));
			temp = Root;
			for (int i = 0; i < letter.Count-1; i++) {
				//Debug.Log(letter[i]);
				int c = int.Parse (letter [i]);
				//Debug.Log (c);
				if (!temp.dict.ContainsKey (c)) {
					Node n = new Node ();
					temp.dict.Add (c, n);
				}
				temp = temp.dict [c];
			}
		}

		query = new List<int> ();
		query.Add (2325);
		query.Add (2369);
		query.Add (2335);
		query.Add (2344);
		query.Add (2346);
		query.Add (2341);
		temp = Root;
		for (int i = 0; i<query.Count; i++) {
			if(temp.dict.ContainsKey (query[i]))
			{
				if(i == query.Count-1)
					Debug.Log ("Machaya");
				else
				{
					temp = temp.dict[query[i]];
					//Debug.Log(query[i]);
				}
			}
			else
			{
				Debug.Log ("Nahi Machaya");
				Debug.Log(query[i]);
				break;
			}
		}
		//2309 2325 2341 2344 2368 2351
		//2325 2369 2335 2344 2346 2344
		/*int k = int.Parse(letter[4]);
		Debug.Log (k);*/
	}
}

