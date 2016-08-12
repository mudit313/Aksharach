using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Scoreprinter : MonoBehaviour {
	public Text High1;
	public Text High2;
	public Text High3;
	public Text High4;
	public Text High5;
	// Use this for initialization
	void Start () {
	
	}
	public void output()
	{
		High1.text = PlayerPrefs.GetInt ("High 1").ToString();
		High2.text = PlayerPrefs.GetInt ("High 2").ToString();
		High3.text = PlayerPrefs.GetInt ("High 3").ToString();
		High4.text = PlayerPrefs.GetInt ("High 4").ToString();
		High5.text = PlayerPrefs.GetInt ("High 5").ToString();
	}
}
