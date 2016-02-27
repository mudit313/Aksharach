using UnityEngine;
using System.Collections;

public class place : MonoBehaviour {
	public GameObject board;
	private bool onboard=false;
	Vector3 bottom;
	void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log ("Hey");
		if (other.gameObject.tag == "board") {
			onboard=true;
		}
	}
	// Update is called once per frame
	void Update () {
		if (onboard == true) {
			bottom = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 0);
			onboard = false;
		}
	}
	void OnMouseUp()
	{
		Debug.Log ("hi");
		Vector3 boardpos = board.transform.position;
		float sizeBoard = boardpos.y-bottom.y;
		float sizeTile = sizeBoard/16;
		boardpos.x += sizeTile;
		boardpos.y += sizeTile;
		Vector3 offset = new Vector3 (Mathf.Abs(Input.mousePosition.x - boardpos.x),Mathf.Abs(Input.mousePosition.y - boardpos.y), 0);
		while (offset.x>sizeTile && offset.y>sizeTile) 
		{
			if(Input.mousePosition.x>boardpos.x)
				boardpos.x+=2*sizeTile;
			else
				boardpos.x-=2*sizeTile;
			if(Input.mousePosition.y>boardpos.y)
				boardpos.y+=2*sizeTile;
			else
				boardpos.y-=2*sizeTile;
			offset.x-=2*sizeTile;
			offset.y-=2*sizeTile;
		}
		Debug.Log ("holla");
		transform.position = boardpos;
	}
}
