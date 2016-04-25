using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {
	public static int Score1,Score2;
	public Text s1,s2;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		s1.text = Score1.ToString ();
		s2.text = Score2.ToString ();
	}
	public static int score(int l ,int r, int u, int d)
	{
		int sc = 0;
		Debug.Log (l+ " " + r + " " + u + " " + d);
		if (l == r) {
			for (int i=u; i<=d; i++)
				sc += (Board.matrix [l, i]*Board.multiples[l,i]);
			for (int i=u; i<=d; i++)
			{
				if(Board.powers[l,i]!=1)
					sc*=Board.powers[l,i];
			}
		} else {
			for(int i=l;i<=r;i++)
				sc+=(Board.matrix [i,u]*Board.multiples[i,u]);
			for (int i=l;i<=r;i++)
			{
				if(Board.powers[i,u]!=1)
					sc*=Board.powers[i,u];
			}
		}
		Debug.Log (sc);
		return sc;
	}
}
