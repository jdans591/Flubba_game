using UnityEngine;
using System.Collections;

public class FinishTrigger : MonoBehaviour {

	void OnTriggerEnter2D () {
		Application.LoadLevel (0);
	}
}
