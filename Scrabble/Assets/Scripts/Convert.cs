using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Convert : MonoBehaviour {
	public TextAsset dicfile;
	//public TextAsset dict;
	private string bigstring;
	private List<string> eachLine;

	// Use this for initialization
	void Start () {
		int k;
		string t;
		bigstring = dicfile.text;
		eachLine = new List<string>();
		eachLine.AddRange(
			bigstring.Split("\n"[0]) );

		int kWords = eachLine.Count;
		//Debug.Log(kWords);

		for (int i=0; i<kWords; i++) {
			for(int j=1;eachLine [i][j] != ']';j++)
			{
				k = (int) (eachLine [i][j]);
				t = k.ToString();
				System.IO.File.AppendAllText ("D:/Git/Team11cs243/Scrabble/Assets/Scripts/Dict.txt", t + ' ');
			}
			System.IO.File.AppendAllText ("D:/Git/Team11cs243/Scrabble/Assets/Scripts/Dict.txt", "\n");
		}
	}
}
