using UnityEngine;
using System.Collections;

public class intersection : MonoBehaviour {
	public GameObject x;
	public GameObject y;
	private bool b=false;
	private Collider2D col;
	//public drag z;;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "vowel") {
			b=true;
			col=other;
		}
	}
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "vowel") {
			b=false;
		}
	}
	void Update()
	{
		if (b==true && Input.GetMouseButtonUp (0) == true) 
		{
			Vector3 pos = transform.position;
			Instantiate (x, pos, Quaternion.identity);
			Destroy (col.gameObject);
			Destroy (y);
		}
	}
}