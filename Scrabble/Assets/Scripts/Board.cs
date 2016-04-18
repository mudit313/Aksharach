using UnityEngine;
using System.Collections;

public class Board : MonoBehaviour {
	public GameObject board;
	public static Vector3 boardpos;
	public static float sizeBoard;
	public static float sizeTile;
	public static int[,] matrix = new int[16, 16];
	public static int[,] unicode = new int[16, 16];
    
    public static int[,] multiples = new int[16,16];
	// Use this for initialization
	void Start () {
		boardpos = new Vector3(board.transform.position.x,board.transform.position.y,0);
		sizeBoard = (float)(boardpos.y+4.21);
		sizeTile = sizeBoard/16;
		for(int i=0;i<16;i++)
		{
			for(int j=0;j<16;j++)
			{
				matrix[i,j]=0;
				unicode[i,j]=0;
			}
		}
        
        for(i=0;i<16;i++)
        {
            for(j=0;j<16;j++)
            {
                multiples[i,j]=1;
            }
        }
        //triple letter tiles
        multiples[0,7]=3;
        multiples[0,8]=3;
        
        multiples[7,0]=3;
        multiples[8,0]=3;
        
        multiples[15,7]=3;
        multiples[15,8]=3;
        
        multiples[7,15]=3;
        multiples[8,15]=3;
        
        multiples[5,5]=3;
        multiples[5,10]=3;
        multiples[10,5]=3;
        multiples[10,10]=3;
        
        //double letter tiles
        multiples[1,5]=2;
        multiples[2,6]=2;
        multiples[3,7]=2;
        multiples[3,8]=2;
        multiples[2,9]=2;
        multiples[1,10]=2;
    
        multiples[5,1]=2;
        multiples[6,2]=2;
        multiples[7,3]=2;
        multiples[8,3]=2;	
        multiples[9,2]=2;
        multiples[10,1]=2;
        
        multiples[14,5]=2;
        multiples[13,6]=2;
        multiples[12,7]=2;
        multiples[12,8]=2;
        multiples[13,9]=2;
        multiples[14,10]=2;
        
        multiples[5,14]=2;
        multiples[6,13]=2;
        multiples[7,12]=2;
        multiples[8,12]=2;
        multiples[9,13]=2;
        multiples[10,14]=2;
        
        multiples[6,6]=2;
        multiples[6,9]=2;
        multiples[9,6]=2;
        multiples[9,9]=2;
    }
    
	
	// Update is called once per frame
	void Update () {
	
	}
}
