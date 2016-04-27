//This script changes the game menu into hindi to allow
//a user of hindi language to help him navigate his way 
//and start the game

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LangChng : MonoBehaviour {




	public GameObject go1;
	public GameObject go1b1;
	public GameObject go1b2;
	public GameObject go1b3;
	//public GameObject go1b4;
	//public GameObject go1b5;

	public GameObject go2;
	public GameObject go2b1;
	public GameObject go2b2;
	public GameObject go2b3;
	public GameObject go2b4;

	public GameObject go3;
	public GameObject go3b1;
	public GameObject go3b2;
	public GameObject go3b3;
	//public GameObject go3b4;
	public GameObject go3b5;
	public GameObject go3b6;
	//public GameObject go3b7;

	public GameObject go4;
	//public GameObject go4b1;

	public GameObject go5b1;
	public GameObject go5b2;
	//public GameObject go5b3;
	//public Button but;

	public Font hindFont;

	// Use this for initialization
	void Start ()
	{
		if (hindFont == null)
		{
			hindFont = (Font)Resources.Load("Fonts/k010.ttf", typeof(Font));
		}
	}

	public void onClick ()
	{

//Each gameObject is set into hindi.
		go1.SetActive (true);
		//go1.SetActive (true);
		go1b1.GetComponentInChildren<Text>().text = "cuke +lxud";
		go1b1.GetComponentInChildren<Text>().font = hindFont;

		go1b2.GetComponentInChildren<Text>().text = "cuke f[kykM-h";
		go1b2.GetComponentInChildren<Text>().font = hindFont;

		go1b3.GetComponentInChildren<Text>().text = "mPp Ldskj";
		go1b3.GetComponentInChildren<Text>().font = hindFont;

		//go1b4.GetComponentInChildren<Text>().text = "fodYi";
		//go1b4.GetComponentInChildren<Text>().font = hindFont;

		//go1b5.GetComponentInChildren<Text>().text = "ckgj";
		//go1b5.GetComponentInChildren<Text>().font = hindFont;
		//go1.SetActive(false);
		go1.SetActive(false);

		go2.SetActive (true);
		//go1.SetActive (true);
		go2b1.GetComponentInChildren<Text>().text = "ihNs";
		go2b1.GetComponentInChildren<Text>().font = hindFont;

		go2b2.GetComponentInChildren<Text>().text = "xkuk 1";
		go2b2.GetComponentInChildren<Text>().font = hindFont;

		go2b3.GetComponentInChildren<Text>().text = "xkuk 2";
		go2b3.GetComponentInChildren<Text>().font = hindFont;

		go2b4.GetComponentInChildren<Text>().text = "xkuk 3";
		go2b4.GetComponentInChildren<Text>().font = hindFont;
		//go1.SetActive(false);
		go2.SetActive(false);

		go3.SetActive (true);
		//go1.SetActive (true);
		go3b1.GetComponentInChildren<Text>().text = "enn";
		go3b1.GetComponentInChildren<Text>().font = hindFont;

		go3b2.GetComponentInChildren<Text>().text = "Js;";
		go3b2.GetComponentInChildren<Text>().font = hindFont;

		go3b3.GetComponentInChildren<Text>().text = "ckjs es";
		go3b3.GetComponentInChildren<Text>().font = hindFont;

		//go3b4.GetComponentInChildren<Text>().text = "vkokt";
		//go3b4.GetComponentInChildren<Text>().font = hindFont;

		go3b5.GetComponentInChildren<Text>().text = "xkuk";
		go3b5.GetComponentInChildren<Text>().font = hindFont;

		go3b6.GetComponentInChildren<Text>().text = "Hkk'kk";
		go3b6.GetComponentInChildren<Text>().font = hindFont;

		//go3b7.GetComponentInChildren<Text>().text = "ihNs";
		//go3b7.GetComponentInChildren<Text>().font = hindFont;
		//go1.SetActive(false);
		go3.SetActive(false);

		go4.SetActive (true);
		//go1.SetActive (true);
		//go4b1.GetComponentInChildren<Text>().text = "ihNs";
		//go4b1.GetComponentInChildren<Text>().font = hindFont;
		//go1.SetActive(false);
		go4.SetActive(false);


		go5b1.GetComponentInChildren<Text>().text = "v+xzs-th";
		go5b1.GetComponentInChildren<Text>().font = hindFont;
		//go5b1.GetComponentInChildren<Font> ().fontSize = 40;

		go5b2.GetComponentInChildren<Text>().text = "fgUnh";
		go5b2.GetComponentInChildren<Text>().font = hindFont;
	
		//go5b3.GetComponentInChildren<Text>().text = "ihNs";
		//go5b3.GetComponentInChildren<Text>().font = hindFont;
	}
}
