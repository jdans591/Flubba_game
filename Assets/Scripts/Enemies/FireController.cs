using UnityEngine;
using System.Collections;

public class FireController : MonoBehaviour {

	public LevelManager levelManager;

	// Used for initialization
	void Start() {
		levelManager = FindObjectOfType<LevelManager>();
	}

	void OnTriggerEnter2D(Collider2D collider) {
		// When player comes into collision with fire, player dies
		if (collider.gameObject.tag == "Player") {
			levelManager.HandleDeath();
		}
	}
}
