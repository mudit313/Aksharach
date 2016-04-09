using UnityEngine;
using System.Collections;

public class Board : MonoBehaviour {
	public GameObject board;
	public static Vector3 boardpos;
	public static float sizeBoard;
	public static float sizeTile;
	public static int[,] matrix=new int[16,16];
	// Use this for initialization
	void Start () {
		boardpos = new Vector3(board.transform.position.x,board.transform.position.y,0);
		sizeBoard = (float)(boardpos.y+4.21);
		sizeTile = sizeBoard/16;
		for(int i=0;i<16;i++)
		{
			for(int j=0;j<16;j++)
				matrix[i,j]=0;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
