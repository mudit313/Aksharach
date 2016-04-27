//This C# script is to change sorting layers
using UnityEngine;
using System.Collections;

public class show : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void OnClick(){
		if (gameObject.GetComponent<SpriteRenderer> ().sortingLayerName == "Background") 
			gameObject.GetComponent<SpriteRenderer> ().sortingLayerName = "Fore";
		else if (gameObject.GetComponent<SpriteRenderer> ().sortingLayerName == "Fore") 
			gameObject.GetComponent<SpriteRenderer> ().sortingLayerName = "Background";
	}
}
