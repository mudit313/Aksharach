using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Chance : MonoBehaviour {
	public static int chance,currsc;
	public static GameObject letteronboard;
	public static bool added=true;
	public static bool accepted= false;
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
			Board.matrix[(int)ind.x,(int)ind.y]+=letteronboard.GetComponentInChildren<Point>().pt;
			//Board.unicode[(int)ind.x,(int)ind.y]=letteronboard.GetComponentInChildren<Point>().Unicode;
			added=true;
		}
	}

	public void OnClick(){
		ValidCheck ();
		if (accepted) {
			Debug.Log("accepted");
			for(int i=0;i<list.Count;i++)
				list[i].GetComponent<place>().placed=true;

			list.Clear();
			if (chance == 1) {
				chance = 2;
				Score.Score1 += currsc;
			} else {
				chance = 1;
				Score.Score2 += currsc;
			}
			accepted=false;
			first=false;
		}
		currsc = 0;
	}
	public void ValidCheck()
	{
		Debug.Log ("checking");
		int i,flag=0;
		Vector2 ind = getIndex (list [0]);
		int line1 = (int)ind.x;
		int line2 = (int)ind.y;
		for (i=1; i<list.Count; i++) {
			if((int)(getIndex (list [i]).x)!=line1)
				break;
		}
		//Debug.Log ();
		if (i<list.Count) {
			for(i=1;i<list.Count;i++)
			{
				if((int)(getIndex(list[i]).y)!=line2)
					return;
			}
			flag=1;
		}
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
		Debug.Log (flag);
		if (flag == 1) {
			line2=line1-1;
			while(line1<16 && Board.matrix[line1,(int)ind.y]!=0)
			{
				currsc+=Board.matrix[line1,(int)ind.y];
				line1++;
			}
			line1--;
			while(line2>=0 && Board.matrix[line2,(int)ind.y]!=0)
			{
				currsc+=Board.matrix[line2,(int)ind.y];
				line2--;
			}
			line2++;
			for (i=1; i<list.Count; i++) {
				Vector2 ind1=getIndex (list [i]);
				Debug.Log(ind1.x);
				if((int)(ind1.x)>line1 || (int)(ind1.x)<line2)
					return;
			}
		}
		else{
			line1=line2+1;
			while(line1<16 && Board.matrix[(int)ind.x,line1]!=0)
			{
				currsc+=Board.matrix[(int)ind.x,line1];
				line1++;
			}
			line1--;
			while(line2>=0 && Board.matrix[(int)ind.x,line2]!=0)
			{
				currsc+=Board.matrix[(int)ind.x,line2];
				line2--;
			}
			line2++;
			for (i=1; i<list.Count; i++) {
				Vector2 ind1=getIndex (list [i]);
				if((int)(ind1.y)<line2 || (int)(ind1.y)>line1)
					return;
			}
		}
		int diff = (line1 - line2) + 1;
		if(diff>list.Count || first)
			accepted = true;
	}
}
