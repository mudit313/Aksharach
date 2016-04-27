//C# script to change the sounds of game menu.
using UnityEngine;
using System.Collections;
 
 public class Sound_change : MonoBehaviour 
 {
     
     public AudioSource _AudioSource1;
     public AudioSource _AudioSource2;
     public AudioSource _AudioSource3;
 
  //Used to close any 2 of the sounds and play the 3rd one.  
     
     
     public void Onclick() {
		_AudioSource1.Play();
		_AudioSource2.Stop();
        _AudioSource3.Stop();
	}
	
 
 }