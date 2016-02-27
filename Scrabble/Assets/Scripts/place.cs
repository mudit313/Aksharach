using UnityEngine;
using System.Collections;

public class place : MonoBehaviour {
	public GameObject board;
	//private bool onboard=false;
	//Vector3 bottom;
	/*void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log ("Hey");
		if (other.gameObject.tag == "board") {
			onboard=true;
		}
	}*/
	// Update is called once per frame
	/*void Update () {
		if (onboard == true) {
			bottom = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 0);
			Debug.Log("Bot");
			onboard = false;
		}
	}*/
	void OnMouseUp()
	{
		Debug.Log ("hi");
		Vector3 boardpos = new Vector3(board.transform.position.x,board.transform.position.y,0);
		float sizeBoard = (float)(boardpos.y+4.21);
		float sizeTile = sizeBoard/16;
		boardpos.x += sizeTile;
		boardpos.y += sizeTile;
		Vector3 offset = new Vector3 (Mathf.Abs(transform.position.x - boardpos.x),Mathf.Abs(transform.position.y - boardpos.y), 0);
		Debug.Log (transform.position.y);
		while (offset.x>sizeTile) {
			if (transform.position.x > boardpos.x) {
				boardpos.x += 2 * sizeTile;
				offset.x -= 2 * sizeTile;
			} else {
				boardpos.x -= 2 * sizeTile;
				offset.x -= 2 * sizeTile;
			}
		}
		while (offset.y>sizeTile) {
			if(transform.position.y>boardpos.y)
			{
				boardpos.y+=2*sizeTile;
				offset.y-=2*sizeTile;
				continue;
			}
			else
			{
				boardpos.y-=2*sizeTile;
				offset.y-=2*sizeTile;
				continue;
			}
		}		
		transform.position = boardpos;
	}
}
