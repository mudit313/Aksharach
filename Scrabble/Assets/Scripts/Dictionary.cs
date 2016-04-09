using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Dictionary : MonoBehaviour {
	public TextAsset dicfile;
	private string whole;
	private List<string> word;
	public string search;
	
	// Use this for initialization
	void Start () {
		whole = dicfile.text;
		
		word = new List<string>();
		word.AddRange(whole.Split("\n"[0]) );

		int n = word.Count;
		//Debug.Log(kWords);
		/*char x2 = 'क';
		int k = (int)(x);
		int k2 = (int)(x2);
		Debug.Log (k);
		Debug.Log (k2);*/
		//int k = (int)(eachLine [20] [2]);
		//Debug.Log(eachLine[20][2]);
		//Debug.Log(k);
		
		/*for (int i=0; i<kWords; i++) {
			string t;
			t = eachLine[i];

		}*/
	}
}
