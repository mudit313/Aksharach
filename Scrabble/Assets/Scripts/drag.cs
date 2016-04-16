using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]

public class drag : MonoBehaviour {
	private Vector3 screenPoint;
	private Vector3 offset;
	public void OnMouseDown() 
	{
<<<<<<< HEAD
		if (gameObject.GetComponent<place> ().onboard != true)
			offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
=======
		if(gameObject.GetComponent<place>().placed==false && gameObject.tag!="mixed")
			offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
		if (gameObject.GetComponent<place>().onboard == true) {
			Vector2 ind=Chance.getIndex(gameObject);
			if(gameObject.tag!="mixed")
			{
				Board.matrix[(int)ind.x,(int)ind.y]-=Chance.letteronboard.GetComponentInChildren<Point>().pt;
				Chance.letteronboard = gameObject;
			}
			else
			{
				//gameObject.GetComponent<intersection>().
			}
		}

>>>>>>> eff7ec2f116205eedac7afbff47c0a4268aee231
	}

	void OnMouseDrag()
	{
		if (gameObject.GetComponent<place>().onboard == false) {
			Vector3 curScreenPoint = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
			Vector3 curPosition = Camera.main.ScreenToWorldPoint (curScreenPoint) + offset;
			transform.position = curPosition;
		}
	}
}