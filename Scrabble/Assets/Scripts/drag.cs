using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]

public class drag : MonoBehaviour {
	private Vector3 screenPoint;
	private Vector3 offset;
	void OnMouseDown() 
	{
		if(gameObject.GetComponent<place>().placed==false)
			offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
		if (gameObject.GetComponent<place>().onboard == true) {
			Vector2 ind=Chance.getIndex(gameObject);
			Board.matrix[(int)ind.x,(int)ind.y]=0;
			Chance.letteronboard = gameObject;
		}

	}
	
	void OnMouseDrag()
	{
		if (gameObject.GetComponent<place>().placed == false) {
			Vector3 curScreenPoint = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
			Vector3 curPosition = Camera.main.ScreenToWorldPoint (curScreenPoint) + offset;
			transform.position = curPosition;
		}
	}
}