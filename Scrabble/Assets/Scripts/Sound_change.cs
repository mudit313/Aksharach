using UnityEngine;
using System.Collections;
 
 public class Sound_change : MonoBehaviour 
 {
     
     public AudioSource _AudioSource1;
     public AudioSource _AudioSource2;
     public AudioSource _AudioSource3;
 
    
     
     
     public void Onclick() {
		_AudioSource1.Play();
		_AudioSource2.Stop();
        _AudioSource3.Stop();
	}
	
 
 }