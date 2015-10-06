using UnityEngine;
using System.Collections;

public class ChangeScene : MonoBehaviour {

	// Changes current focus to specified scene (find scene by number under file -> Build Settings in Unity)
	public void ChangeToScene (int sceneToChangeTo) {
		Application.LoadLevel (sceneToChangeTo);
	}
}
