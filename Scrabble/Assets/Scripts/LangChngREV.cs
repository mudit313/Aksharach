using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LangChngREV : MonoBehaviour {
	public GameObject go1;
	public GameObject go1b1;
	public GameObject go1b2;
	public GameObject go1b3;
	public GameObject go1b4;
	public GameObject go1b5;

	public GameObject go2;
	public GameObject go2b1;
	public GameObject go2b2;
	public GameObject go2b3;
	public GameObject go2b4;

	public GameObject go3;
	public GameObject go3b1;
	public GameObject go3b2;
	public GameObject go3b3;
	public GameObject go3b4;
	public GameObject go3b5;
	public GameObject go3b6;
	public GameObject go3b7;

	public GameObject go4;
	public GameObject go4b1;

	public GameObject go5b1;
	public GameObject go5b2;
	public GameObject go5b3;
	//public Button but;

	// Use this for initialization
	public Font EngFont;
	
	// Use this for initialization
	void Start ()
	{
		if (EngFont == null)
		{
			EngFont = (Font)Resources.Load("Fonts/k010.ttf", typeof(Font));
		}
	}

	public void onClick ()
	{
		go1.SetActive (true);
		//go1.SetActive (true);
		go1b1.GetComponentInChildren<Text>().text = "Vs CPU";
		go1b1.GetComponentInChildren<Text>().font = EngFont;

		go1b2.GetComponentInChildren<Text>().text = "Vs Player";
		go1b2.GetComponentInChildren<Text>().font = EngFont;

		go1b3.GetComponentInChildren<Text>().text = "High Score";
		go1b3.GetComponentInChildren<Text>().font = EngFont;

		go1b4.GetComponentInChildren<Text>().text = "Options";
		go1b4.GetComponentInChildren<Text>().font = EngFont;

		go1b5.GetComponentInChildren<Text>().text = "Exit";
		go1b5.GetComponentInChildren<Text>().font = EngFont;
		//go1.SetActive(false);
		go1.SetActive(false);

		go2.SetActive (true);
		//go1.SetActive (true);
		go2b1.GetComponentInChildren<Text>().text = "Back";
		go2b1.GetComponentInChildren<Text>().font = EngFont;

		go2b2.GetComponentInChildren<Text>().text = "Slow";
		go2b2.GetComponentInChildren<Text>().font = EngFont;

		go2b3.GetComponentInChildren<Text>().text = "Rock";
		go2b3.GetComponentInChildren<Text>().font = EngFont;

		go2b4.GetComponentInChildren<Text>().text = "Pop";
		go2b4.GetComponentInChildren<Text>().font = EngFont;
		//go1.SetActive(false);
		go2.SetActive(false);

		go3.SetActive (true);
		//go1.SetActive (true);
		go3b1.GetComponentInChildren<Text>().text = "Help";
		go3b1.GetComponentInChildren<Text>().font = EngFont;

		go3b2.GetComponentInChildren<Text>().text = "Credits";
		go3b2.GetComponentInChildren<Text>().font = EngFont;

		go3b3.GetComponentInChildren<Text>().text = "About";
		go3b3.GetComponentInChildren<Text>().font = EngFont;

		go3b4.GetComponentInChildren<Text>().text = "Sound";
		go3b4.GetComponentInChildren<Text>().font = EngFont;

		go3b5.GetComponentInChildren<Text>().text = "Music";
		go3b5.GetComponentInChildren<Text>().font = EngFont;

		go3b6.GetComponentInChildren<Text>().text = "Language";
		go3b6.GetComponentInChildren<Text>().font = EngFont;

		go3b7.GetComponentInChildren<Text>().text = "Back";
		go3b7.GetComponentInChildren<Text>().font = EngFont;
		//go1.SetActive(false);
		go3.SetActive(false);

		go4.SetActive (true);
		//go1.SetActive (true);
		go4b1.GetComponentInChildren<Text>().text = "Back";
		go4b1.GetComponentInChildren<Text>().font = EngFont;
		//go1.SetActive(false);
		go4.SetActive(false);


		go5b1.GetComponentInChildren<Text>().text = "English";
		go5b1.GetComponentInChildren<Text>().font = EngFont;

		go5b2.GetComponentInChildren<Text>().text = "Hindi";
		go5b2.GetComponentInChildren<Text>().font = EngFont;

		go5b3.GetComponentInChildren<Text>().text = "Back";
		go5b3.GetComponentInChildren<Text>().font = EngFont;
	}
}
