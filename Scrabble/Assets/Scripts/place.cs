using UnityEngine;
using System.Collections;

public class place : MonoBehaviour {
	public GameObject board;
	//public static int sc=0;
	public bool onboard = false;

	// Update is called once per frame
	void Update () {
		if (transform.position.y > -4.22 && !onboard) {
			if(Chance.letteronboard != null)
				Chance.xletter = Chance.letteronboard;
			Chance.letteronboard = gameObject;
			gameObject.GetComponent<place>().onboard = true;
			Chance.added = false;
		}
	}

	void OnMouseUp()
	{
		//Debug.Log ("hi");
		Vector3 boardpos = new Vector3(board.transform.position.x,board.transform.position.y,0);
		float sizeBoard = (float)(boardpos.y+4.21);
		float sizeTile = sizeBoard/16;
		boardpos.x += sizeTile;
		boardpos.y += sizeTile;
		Vector3 offset = new Vector3 (Mathf.Abs(transform.position.x - boardpos.x),Mathf.Abs(transform.position.y - boardpos.y), 0);
		//Debug.Log (transform.position.y);
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
