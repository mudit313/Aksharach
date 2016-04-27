//This C# script helps in placing the letters on board 
//It is associated with all letters
using UnityEngine;
using System.Collections;

public class place : MonoBehaviour {

	public bool onboard = false;//for letter to be onboard, intersection possible
	public bool placed= false;//for letter to be placed, intersection not possible
	public bool ontop= false;//intersection happening
	public Vector3 initialpos;//position of letter on rack
	void Start()
	{
		initialpos = transform.position;
	}
	// Update is called once per frame 00
	void Update () {
	}

	//this function is called when the mouse button is let go after dragging
	void OnMouseUp()
	{
		//Debug.Log (Chance.currsc);
		if (transform.position.y > -4.22 && !onboard) {
			//Calculates position of the board tile on which 
			//letter should be placed using board size, tile size and current letter position 
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
			Chance.letteronboard = gameObject;
			onboard=true;
			Chance.added = false;//triggers the update function in Chance script active
		}
		else if(!onboard){
			transform.position=initialpos;
			onboard=false;
		}
	}
}
