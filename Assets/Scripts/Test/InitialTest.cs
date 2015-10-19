using UnityEngine;
using System.Collections;
/**
* A test to ascertain that the level manager has been initialised correctly
 */
public class InitialTest : MonoBehaviour {
	
	LevelManager LM;

	void Start() {
		var levelManager = GameObject.Find ("Level Manager");
		if (levelManager != null)
			IntegrationTest.Pass ();

	}

}
