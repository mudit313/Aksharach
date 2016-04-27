//C# script to hide/show the game Objects. Used for menu implemetation.
using UnityEngine;
using System.Collections;

public class change_obj : MonoBehaviour {
	public GameObject GameObject1;
	public GameObject GameObject2;
	// Use this for initialization
	public void Onclick() {
		GameObject1.SetActive (false);
		GameObject2.SetActive (true);
	}
	

}
