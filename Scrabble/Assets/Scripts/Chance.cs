using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Chance : MonoBehaviour {
	public static int chance,currsc;
	public static GameObject letteronboard;
	public static bool added=true;
	public static bool added2=true;
	public static bool accepted=false;
	public static bool first=true;
	public static List<GameObject> list=new List<GameObject>();
	// Use this for initialization
	void Start () {
		chance = 1;
	}
	public static Vector2 getIndex(GameObject g)
	{
		int x = (int)(8 + (g.transform.position.x - Board.boardpos.x) / (2 * Board.sizeTile));
		int y = (int)(8 - (g.transform.position.y - Board.boardpos.y) / (2 * Board.sizeTile));
		return new Vector2 (x, y);
	}

	void Update () {
		if (!added && letteronboard != null) {
			Vector2 ind=getIndex(letteronboard);
			if(Board.matrix[(int)ind.x,(int)ind.y]>0)
			{
				if(letteronboard.GetComponent<place>().ontop==true)
					added2=false;
				else{
					letteronboard.transform.position=letteronboard.GetComponent<place>().initialpos;
					letteronboard.GetComponent<place>().onboard=false;
					return;
				}
			}
			//Debug.Log(letteronboard.GetComponentInChildren<Point>().Unicode);
			Board.matrix[(int)ind.x,(int)ind.y]+=letteronboard.GetComponentInChildren<Point>().pt;
			list.Add(letteronboard);
			Debug.Log(Board.matrix[(int)ind.x,(int)ind.y]);
			//Board.unicode[(int)ind.x,(int)ind.y]=letteronboard.GetComponentInChildren<Point>().Unicode;
			added=true;
		}
	}

	public void OnClick(){
		ValidCheck ();
		if (accepted) {
			Debug.Log ("accepted");
			list.Clear ();
			if (chance == 1) {
				chance = 2;
				Score.Score1 += currsc;
			} else {
				chance = 1;
				Score.Score2 += currsc;
			}
			accepted = false;
			first = false;
		} else {
			Recall.recall();
		}
		currsc = 0;
	}
	public void ValidCheck()
	{
		Debug.Log ("checking");
		int i,flag=0,count=0;
		Vector2 ind = getIndex (list [0]);
		int line1 = (int)ind.x;
		int line2 = (int)ind.y;

		//loop to count number of active letters
		for (i=0; i<list.Count; i++)
			if (list [i].activeSelf)
				count++;

		//2 for loops to know horizontal or vertical
		for (i=1; i<list.Count; i++) {
			if(list[i].activeSelf &&(int)(getIndex (list [i]).x)!=line1)
				break;
		}
		//Debug.Log ();
		if (i<list.Count) {
			for(i=1;i<list.Count;i++)
			{
				if(list[i].activeSelf &&(int)(getIndex(list[i]).y)!=line2)
					return;
			}
			flag=1;
		}
		//block to avoid discreet entries
		if (count == 1) {
			if ((int)ind.x < 15 && Board.matrix [(int)(ind.x) + 1, (int)ind.y] != 0)
				flag = 1;
			else if ((int)ind.x > 0 && Board.matrix [(int)(ind.x) - 1, (int)ind.y] != 0)
				flag = 1;
			else if ((int)ind.y < 15 && Board.matrix [(int)ind.x, (int)(ind.y) + 1] != 0)
				flag = 0;
			else if ((int)ind.y > 0 && Board.matrix [(int)ind.x, (int)(ind.y) - 1] != 0)
				flag = 0;
			else 
				return;
		}
		Debug.Log (flag);
		//1 for horizontal 0 for vertical
		if (flag == 1) {
			line2=line1-1;
			while(line1<16 && Board.matrix[line1,(int)ind.y]!=0)
			{
				//currsc+=Board.matrix[line1,(int)ind.y];
				line1++;
			}
			line1--;
			while(line2>=0 && Board.matrix[line2,(int)ind.y]!=0)
			{
				//currsc+=Board.matrix[line2,(int)ind.y];
				line2--;
			}
			line2++;
			for (i=0; i<list.Count; i++) {
				Vector2 ind1=getIndex (list [i]);
				if((int)(ind1.x)>line1 || (int)(ind1.x)<line2 || (int)(ind1.y)!=(int)(ind.y))
					return;
			}
			currsc=Score.score(line2,line1,(int)(ind.y),(int)ind.y);
		}
		else{
			line1=line2+1;
			while(line1<16 && Board.matrix[(int)ind.x,line1]!=0)
			{
				//currsc+=Board.matrix[(int)ind.x,line1];
				line1++;
			}
			line1--;
			while(line2>=0 && Board.matrix[(int)ind.x,line2]!=0)
			{
				//currsc+=Board.matrix[(int)ind.x,line2];
				line2--;
			}
			line2++;
			for (i=0; i<list.Count; i++) {
				Vector2 ind1=getIndex (list [i]);
				if((int)(ind1.y)<line2 || (int)(ind1.y)>line1 || (int)(ind1.x)!=(int)(ind.x))
					return;
			}
			currsc=Score.score((int)(ind.x),(int)ind.x,line2,line1);
		}
		int diff = (line1 - line2) + 1;
		if(diff>count || first)
			accepted = true;
	}
}
