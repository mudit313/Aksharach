//This C# script is used to drag a tile
//It is associated with all alphabet tiles
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]

public class drag : MonoBehaviour {
	private Vector3 screenPoint;
	private Vector3 offset;
	public void OnMouseDown() 
	{
		Debug.Log (gameObject.tag);
		if (gameObject.tag!="mixed" && gameObject.GetComponent<place> ().onboard != true)
			offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
	}


	void OnMouseDrag()
	{
		//cannot be a mixed letter
		if (gameObject.tag!="mixed" && gameObject.GetComponent<place>().onboard == false) {
			Vector3 curScreenPoint = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
			Vector3 curPosition = Camera.main.ScreenToWorldPoint (curScreenPoint) + offset;
			transform.position = curPosition;
		}
	}
}