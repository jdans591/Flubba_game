using UnityEngine;
using System.Collections;

/**
 * Simple test to ascertain that after the player dies it respawns at the correct location and updates the death counter
 */
public class PlayerDeathTest : MonoBehaviour {

	LevelManager LM;

	void Start() {
		var levelManager = GameObject.Find("Level Manager");
		LM = levelManager.GetComponent<LevelManager>();
		LM.HandleDeath();

		if (LM.currentFlubba.transform.position == LM.currentCheckpoint.transform.position && LM.deathCount.deathCount > 0) {
			IntegrationTest.Pass();
		}
	}
}
