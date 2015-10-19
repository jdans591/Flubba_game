using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	public bool isPaused;
	public bool disabled;
	public GameObject pauseMenuCanvas;

	void Update() {
		// Check if pause menu has been disabled by end menu (due to flubba reaching end of level)
		if (disabled == false) {
			if (isPaused) {
				// Stop the world, display pause menu
				pauseMenuCanvas.SetActive(true);
				Time.timeScale = 0f;
			} else {
				// Resume the world, hide pause menu
				pauseMenuCanvas.SetActive(false);
				Time.timeScale = 1f;
			}

			// Unpausing
			if (Input.GetKeyDown(KeyCode.Escape)) {
				isPaused = !isPaused;
			}
		}
	}

	// Called upon button click to resume game
	public void resume() {
		isPaused = !isPaused;
	}

	// Called upon button click to change scene back to main menu
	public void backToMainMenu() {
		Application.LoadLevel("main_menu");
	}

	// Changes current focus to specified scene (find scene by number under file -> Build Settings in Unity)
	public void ChangeToScene(string sceneToChangeTo) {
		Application.LoadLevel(sceneToChangeTo);
	}
}
