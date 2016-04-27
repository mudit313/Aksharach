//This C# script is to create matras when vowels meet consonants(swars meet vyanjans)
//It is associated with all vyanjans
using UnityEngine;
using System.Collections;

public class intersection : MonoBehaviour {
	public GameObject x;//stores the mixed gameobject
	public GameObject y;//stores the vyanjan
	public bool ismixed=false;
	public Collider2D col;
	//public drag z;;

	public GameObject[] arr;//array stores all mixed letters of associated vyanjan
	//gaps are maintained for direct indexing using unicode

	//enters when swar enters vyanjan
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "vowel" && gameObject.GetComponent<place> ().placed == false) {
			Debug.Log("entered");
			string s = other.gameObject.GetComponentInChildren<Point> ().Unicode;
			int a = int.Parse (s.Substring (s.Length - 2));
			Debug.Log(a);
			if (a>=6 && a<=24 && arr[a-6]!=null) {//intersection possible
				x = arr [a-6];//choosing which intersection letter(direct indexing)
			}
			other.gameObject.GetComponent<place>().ontop=true;
			y.GetComponent<place>().ontop=true;
			col=other;
		}

	}
	void OnTriggerExit2D(Collider2D other)//enters when swar exits vyanjan
		//it is used to make the process reversible
	{
		if (other.gameObject.tag == "vowel" && gameObject.GetComponent<place>().placed==false) {
			Debug.Log("Exited");
			x=null;
			other.gameObject.GetComponent<place>().ontop=false;
			y.GetComponent<place>().ontop=false;
		}
	}
	void Update()
	{
		//Debug.Log (b);
		if (Chance.added2 == false && y.GetComponent<place>().ontop== true) {
			Debug.Log ("mixed");
			Vector3 pos = y.transform.position;
			x=(GameObject.Instantiate (x, pos, Quaternion.identity) as GameObject);
			//Instantiates the mixed letter at same position
			Chance.list.Add(x);
			Debug.Log ("added");
			Vector2 ind=Chance.getIndex(y);
			Board.unicode[(int)ind.x,(int)ind.y]=x.GetComponentInChildren<Point>().Unicode;
			//Debug.Log(Board.unicode[(int)ind.x,(int)ind.y]);
			col.gameObject.SetActive (false);//makes the swar hidden
			y.SetActive (false);//makes the vyanjan hidden
			Chance.added2 = true;
			y.GetComponent<place>().ontop=false;
		}
	}
}