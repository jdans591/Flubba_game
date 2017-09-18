using UnityEngine;
using System.Collections;

public class FinishTrigger : MonoBehaviour {

	// Return to main menu
	void OnTriggerEnter2D() {
		Application.LoadLevel(0);
	}
}
