using UnityEngine;
using System.Collections;

public class intersection : MonoBehaviour {
	public GameObject x;
	public GameObject y;
	public bool ismixed=false;
	public Collider2D col;
	//public drag z;;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "vowel") {
			other.gameObject.GetComponent<place>().ontop=true;
			//y.GetComponent<place>().ontop=true;
			Debug.Log ("entered");
			col=other;
		}
	}
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "vowel") {
			Debug.Log("Exited");
			other.gameObject.GetComponent<place>().ontop=false;
		}
	}
	void Update()
	{
		//Debug.Log (b);
		if (Chance.added2 == false) {
			Debug.Log ("mixed");
			Vector3 pos = y.transform.position;
			x = (GameObject)Instantiate (x, pos, Quaternion.identity);
			Chance.list.Add(x);
			col.gameObject.SetActive (false);
			y.SetActive (false);
			Chance.added2 = true;

		}
	}
}