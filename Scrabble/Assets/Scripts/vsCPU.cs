using UnityEngine;
using System.Collections;

public class vcCPU : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	public void CPUmodeset()
	{
		PlayerPrefs.SetInt("GameMode", 0);


		// If there is no entry for isFirstTime means it is first time or if there is entry 
		//and it is not one means it is first time
		if (!PlayerPrefs.HasKey ("isFirstTime") || PlayerPrefs.GetInt ("isFirstTime") == 1) {
			// Set and save all your PlayerPrefs here.
			PlayerPrefs.SetInt ("High 1", 0);
			PlayerPrefs.SetInt ("High 2", 0);
			PlayerPrefs.SetInt ("High 3", 0);
			PlayerPrefs.SetInt ("High 4", 0);
			PlayerPrefs.SetInt ("High 5", 0);
			// Now set the value of isFirstTime to be false in the PlayerPrefs.
			PlayerPrefs.SetInt ("isFirstTime", 1);
			PlayerPrefs.Save ();
		} 
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
