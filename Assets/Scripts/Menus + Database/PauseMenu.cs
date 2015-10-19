using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	public bool isPaused;
	public bool disabled;
	public GameObject pauseMenuCanvas;

	// Update is called once per frame
	void Update () {
        // check if pause menu has been disabled by end menu (due to flubba reaching end of level)
		if (disabled == false) {
			if (isPaused) {
                // stop the world, display pause menu
				pauseMenuCanvas.SetActive (true);
				Time.timeScale = 0f;
			} else {
                // resume the world, hide pause menu
				pauseMenuCanvas.SetActive (false);
				Time.timeScale = 1f;
			}
				
			if (Input.GetKeyDown (KeyCode.Escape)) {
				isPaused = !isPaused;
			}
		}
	}

    // called upon button click to resume game
	public void resume () {
		isPaused = !isPaused;
	}

    // called upon button click to change scene back to main menu
	public void backToMainMenu () {
		Application.LoadLevel ("main_menu");
	}

    // Changes current focus to specified scene (find scene by number under file -> Build Settings in Unity)
    public void ChangeToScene(string sceneToChangeTo)
    {
        Application.LoadLevel(sceneToChangeTo);
    }
}
