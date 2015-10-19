using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour {

	public LevelManager levelManager;
	public bool isChecked = false;

	// Used for initialization
	void Start() {
		// Find the level manager and reference it
		levelManager = FindObjectOfType<LevelManager>();
	}

	void OnTriggerEnter2D(Collider2D other) {
		// If the player comes into contact with the checkpoint, set it as the current
		if (other.gameObject.tag == "Player" && !isChecked) {
			levelManager.currentCheckpoint = gameObject;
			isChecked = true;
		}
	}
}
