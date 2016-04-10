using UnityEngine;
using System.Collections;

public class place : MonoBehaviour {

	public bool onboard = false;
	public bool placed =false;

	// Update is called once per frame
	void Update () {
		if (transform.position.y > -4.22 && !onboard) {
			Chance.letteronboard = gameObject;
			Chance.list.Add(gameObject);
			gameObject.GetComponent<place>().onboard = true;
		}
	}

	void OnMouseUp()
	{
		//Debug.Log (Chance.currsc);
		Vector3 boardpos = Board.boardpos;
		float sizeTile = Board.sizeTile;
		boardpos.x += sizeTile;
		boardpos.y += sizeTile;
		Vector3 offset = new Vector3 (Mathf.Abs (transform.position.x - boardpos.x), Mathf.Abs (transform.position.y - boardpos.y), 0);
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
			if (transform.position.y > boardpos.y) {
				boardpos.y += 2 * sizeTile;
				offset.y -= 2 * sizeTile;
				continue;
			} else {
				boardpos.y -= 2 * sizeTile;
				offset.y -= 2 * sizeTile;
				continue;
			}
		}		
		transform.position = boardpos;
		//Chance.added = false;
	}
}
