using UnityEngine;
using System.Collections;

public class BunsenBurnerController : MonoBehaviour {

	public bool fireOn;
	public GameObject firePrefab;

	GameObject fireSpawn;
	GameObject currentFire;

	private AudioSource audio;

	void Awake() {
		// Retrieve audio source for the bunsen burner
		audio = GetComponent<AudioSource>();
		// Attain child game object for the fire spawn of the bunsen burner
		fireSpawn = this.gameObject.transform.GetChild(0).gameObject;
		// Bunsen burner is off by default
		fireOn = false;
	}

	void Start() {
		// Function is repeated every 2 seconds after the first 3 seconds
		InvokeRepeating("OperateFire", 3, 2F);
	}

	void OperateFire() {
		// If the bunsen burner is off, set to be on and instantiate Fire gameobject by spawn
		// also play sound
		if (!fireOn) {
			audio.Play();
			currentFire = Instantiate(firePrefab, fireSpawn.transform.position,
				transform.rotation) as GameObject;
			fireOn = true;
		}
		// If the bunsen burner is on, set to be off and destroy current Fire gameobject
		// also stop sound
		else {
			audio.Stop();
			Destroy(currentFire);
			fireOn = false;
		}
	}
}
