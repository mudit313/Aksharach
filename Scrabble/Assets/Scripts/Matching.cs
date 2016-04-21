using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Matching : MonoBehaviour {
	//public GameObject g;
	// Use this for initialization
	void Start () {
	
	}
	static bool ismixed(int n)
	{
		if ((n >= 2366 && n <= 2381) || n == 2306 || n == 2307)
			return true;
		return false;
	}
	public static int match(int l ,int r, int u, int d, int flag){
		//GameObject g;
		Debug.Log (l+ " " + r + " " + u + " " + d + " " + flag);
		List <int> store= new List<int>();
		int count;
		if (l == r) {
			count=d-u;
			for (int i=u; i<=d; i++) {
				if (Board.unicode [l, i].Length > 4) {
					store.Add (int.Parse (Board.unicode [l, i].Substring (0, 4)));
					store.Add (int.Parse (Board.unicode [l, i].Substring (5, 4)));
				} else
					store.Add (int.Parse (Board.unicode [l, i]));
			}
		} else {
			count=r-l;
			for(int i=l;i<=r;i++) {
				if (Board.unicode [i,u].Length > 4) {
					store.Add (int.Parse (Board.unicode [i,u].Substring (0, 4)));
					store.Add (int.Parse (Board.unicode [i,u].Substring (5, 4)));
				} else
					store.Add (int.Parse (Board.unicode [i,u]));
			}
		}
		while (count>0) {
			if(Dictionary.Search(store) == 1)
				return count;
			if(flag==0){
				store.RemoveAt(0);
				if(ismixed(store[0]))
					store.RemoveAt(0);
			}else{
				int x=store[store.Count-1];
				store.RemoveAt(store.Count-1);
				if(ismixed(x))
					store.RemoveAt(store.Count-1);
			}
			count--;
		}
		return count;
	}
	// Update is called once per frame
	void Update () {
	
	}
}
