using UnityEngine;
using System.Collections;
/**
 * A test to check that the death counter correctly tracks how many times the player has died
 */
public class DeathCountTest : MonoBehaviour {
	LevelManager LM;
	// Use this for initialization
	void Start () {
	
		var levelManager = GameObject.Find("Level Manager");
		LM = levelManager.GetComponent<LevelManager>();
		for(int i = 0; i < 1000; i++)
			LM.HandleDeath();

		if (LM.deathCount.deathCount == 1000)
			IntegrationTest.Pass ();
	}
	

}
