using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HindiUnicode : MonoBehaviour {
	private char[] let;
	private int val;
	// Use this for initialization
	void Start () {
		let = new char[41];
		let[0] = 'अ';
		let[1] = 'आ';
		let[2] = 'इ';
		let[3] = 'ई';
		let[4] = 'उ';
		let[5] = 'ऊ';
		let[6] = 'ए';
		let[7] = 'ऐ';
		let[8] = 'ओ';
		let[9] = 'औ';
		let[10] = 'क';
		let[11] = 'ख';
		let[12] = 'ग';
		let[13] = 'घ';
		let[14] = 'च';
		let[15] = 'छ';
		let[16] = 'ज';
		let[17] = 'झ';
		let[18] = 'ट';
		let[19] = 'ठ';
		let[20] = 'ड';
		let[21] = 'ढ';
		let[22] = 'त';
		let[23] = 'थ';
		let[24] = 'द';
		let[25] = 'द';
		let[26] = 'ध';
		let[27] = 'न';
		let[28] = 'प';
		let[29] = 'फ';
		let[30] = 'ब';
		let[31] = 'भ';
		let[32] = 'म';
		let[33] = 'य';
		let[34] = 'र';
		let[35] = 'ल';
		let[36] = 'व';
		let[37] = 'श';
		let[38] = 'ष';
		let[39] = 'स';
		let[40] = 'ह';
		for (int i = 0; i<41; i++) {
			val = (int)(let[i]);
			Debug.Log(val);
		}
	}
}
