using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]

public class drag : MonoBehaviour {
	private Vector3 screenPoint;
	private Vector3 offset;
	//public static bool isDragging=false;
	
	void OnMouseDown() {
		//Debug.Log ("hey");
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
	}
	
	void OnMouseDrag()
	{
		//Debug.Log ("hi");
		Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
		transform.position = curPosition;
		//isDragging = true;
	}
	/*void OnMouseUp()
	{
		isDragging = false;
	}*/
}