using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Chance : MonoBehaviour {
	public static int chance,currsc;
	public Vector3 diff;
	public static GameObject letteronboard;
	public static bool added=true;
	public static bool accepted= false;
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
			Board.matrix[(int)ind.x,(int)ind.y]=letteronboard.GetComponentInChildren<Point>().pt;
			//Debug.Log(Board.matrix[(int)ind.x,(int)ind.y]);
			//Debug.Log((int)ind.x);
			//Debug.Log((int)ind.y);
			/*if(ind.x<15 && Board.matrix[(ind.x)+1,ind.y]==0)
				Board.matrix[(ind.x)+1,ind.y]=-1;
			if(ind.x>0 && Board.matrix[(ind.x)-1,ind.y]==0)
				Board.matrix[(ind.x)-1,ind.y]=-1;
			if(ind.y<15 && Board.matrix[ind.x,(ind.y)+1]==0)
				Board.matrix[ind.x,(ind.y)+1]=-1;
			if(ind.y>0 && Board.matrix[ind.x,(ind.y)-1]==0)
				Board.matrix[ind.x+1,ind.y]=-1;*/
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
		}
		currsc = 0;
	}
	public void ValidCheck()
	{
		Debug.Log ("checking");
		int i,flag=0;
		int line1 = (int)getIndex (list [0]).x;
		int line2 = (int)getIndex (list [0]).y;
		for (i=1; i<list.Count; i++) {
			if((int)(getIndex (list [i]).x)!=line1)
				break;
		}
		Debug.Log (list.Count);
		if (i<list.Count) {
			for(i=1;i<list.Count;i++)
			{
				if((int)(getIndex(list[i]).y)!=line2)
					return;
			}
			flag=1;
		}
		if (flag == 1) {
			line2=line1;
			for(i=0;i<list.Count;i++)
			{
				Vector2 ind=Chance.getIndex(list[i]);
				if((int)ind.x>line2)
				{
					for(int j=line2+1;j<=(int)ind.x;j++)
					{
						if(Board.matrix[j,(int)ind.y]==0)
							return;
						currsc+=Board.matrix[j,(int)ind.y];
					}
					line2=(int)ind.x;
				}
				else if((int)ind.x<line1)
				{
					for(int j=(int)ind.x;j<line1;j++)
					{
						if(Board.matrix[j,(int)ind.y]==0)
							return;
						currsc+=Board.matrix[j,(int)ind.y];
					}
					line1=(int)ind.x;
				}
			}
		}
		else{
			line1=line2;
			for(i=0;i<list.Count;i++)
			{
				Vector2 ind=Chance.getIndex(list[i]);
				if((int)ind.y>line2)
				{
					for(int j=line2+1;j<=(int)ind.y;j++)
					{
						if(Board.matrix[(int)ind.x,j]==0)
							return;
						currsc+=Board.matrix[(int)ind.x,j];
					}
					line2=(int)ind.y;
				}
				else if((int)ind.y<line1)
				{
					for(int j=(int)ind.y;j<line1;j++)
					{
						if(Board.matrix[(int)ind.x,j]==0)
							return;
						currsc+=Board.matrix[(int)ind.x,j];
					}
					line1=(int)ind.y;
				}
			}
		}
	}
}
