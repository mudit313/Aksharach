using UnityEngine;
using System.Collections;

public class HS : MonoBehaviour {


	public static int [] harray = new int[] { 0, 0, 0, 0, 0};
	public static int p1s=0;
	public static int p2s=0;

	// Use this for initialization
	void Start () {

		Debug.Log (PlayerPrefs.GetInt("GameMode"));

		/*
		PlayerPrefs.SetInt("High 1", 0);
		PlayerPrefs.SetInt("High 2", 0);
		PlayerPrefs.SetInt("High 3", 0);
		PlayerPrefs.SetInt("High 4", 0);
		PlayerPrefs.SetInt("High 5", 0);
		*/
		/*
		Debug.Log (PlayerPrefs.GetInt("High 1"));
		Debug.Log (PlayerPrefs.GetInt("High 2"));
		Debug.Log (PlayerPrefs.GetInt("High 3"));
		Debug.Log (PlayerPrefs.GetInt("High 4"));
		Debug.Log (PlayerPrefs.GetInt("High 5"));
		*/

	
	}

	public void HSf() {

		harray [0] = PlayerPrefs.GetInt ("High 1");
		harray [1] = PlayerPrefs.GetInt ("High 2");
		harray [2] = PlayerPrefs.GetInt ("High 3");
		harray [3] = PlayerPrefs.GetInt ("High 4");
		harray [4] = PlayerPrefs.GetInt ("High 5");


		if (PlayerPrefs.GetInt ("GameMode") == 0) {

//Single player mode
			p1s = Score.Score1;
//Entering the player 1 score if it is eligible for high score
			if(p1s>harray[4])
			{
				harray[4]=p1s;
			}

			for(int i=0;i<5;i++)
			{
				for(int j=0;j<5-i;j++)
				{
					if(harray[j]<harray[j+1])
					{
						int temp=harray[j];
						harray[j]=harray[j+1];
						harray[j+1]=temp;
					}
				}
			}

		} else if ((PlayerPrefs.GetInt ("GameMode")) == 1) {
//Single player mode
			p1s = Score.Score1;
			p2s = Score.Score2;

//Entering the player 1 score if it is eligible for high score
			if(p1s>harray[4])
			{
				harray[4]=p1s;
			}
			
			for(int i=0;i<5;i++)
			{
				for(int j=0;j<5-i;j++)
				{
					if(harray[j]<harray[j+1])
					{
						int temp=harray[j];
						harray[j]=harray[j+1];
						harray[j+1]=temp;
					}
				}
			}
//Entering the player 1 score if it is eligible for high score
			if(p2s>harray[4])
			{
				harray[4]=p2s;
			}
			
			for(int i=0;i<5;i++)
			{
				for(int j=0;j<5-i;j++)
				{
					if(harray[j]<harray[j+1])
					{
						int temp=harray[j];
						harray[j]=harray[j+1];
						harray[j+1]=temp;
					}
				}
			}



		}

//Saving the highscore array

		PlayerPrefs.SetInt("High 1", harray[0]);
		PlayerPrefs.SetInt("High 2", harray[1]);
		PlayerPrefs.SetInt("High 3", harray[2]);
		PlayerPrefs.SetInt("High 4", harray[3]);
		PlayerPrefs.SetInt("High 5", harray[4]);



	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
