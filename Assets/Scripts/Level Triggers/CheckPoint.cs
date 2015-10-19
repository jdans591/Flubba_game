using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour {

	public LevelManager levelManager;
	public bool isChecked = false;

	// Use this for initialization
	void Start () {
        //find the level manager and reference it
		levelManager = FindObjectOfType<LevelManager> ();
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag == "Player" && !isChecked) {
			levelManager.currentCheckpoint = gameObject;
			isChecked = true;
		}
	}
}
