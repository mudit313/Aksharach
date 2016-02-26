using UnityEngine;
using System.Collections;

public class SceneChange : MonoBehaviour {


	public void ChangeToScene (int sceneToChangeTo) {

		Application.LoadLevel (sceneToChangeTo);
	
	}
}
