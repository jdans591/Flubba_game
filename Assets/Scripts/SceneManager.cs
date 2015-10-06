using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour {

	// Changes current focus to specified scene (find scene by number under file -> Build Settings in Unity)
	public void ChangeToScene (string sceneToChangeTo) {
		Application.LoadLevel (sceneToChangeTo);
	}

	// Exits the game
	public void QuitGame () {
		Application.Quit ();
	}
}
