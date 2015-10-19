using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public GameObject startPoint;
	public DeathCount deathCount;
	public GameObject currentCheckpoint;
	public AudioClip deathAudioClip;

	//Alternate skins for the player
	public GameObject currentFlubba;
	public GameObject green;
	public GameObject lightblue;
	public GameObject blue;
	public GameObject red;
	public GameObject orange;
	public GameObject purple;

	private GameObject flubba;
	private AudioSource audio;

	// Set Flubba skins
	void Awake() {
		// Use the PlayerPrefs value to determine which skin is currently equipped,
		// then create a gameobject of that type 
		switch (PlayerPrefs.GetInt("Current Skin")) {
			case 1:
				flubba = green;
				break;
			case 2:
				flubba = blue;
				break;
			case 3:
				flubba = lightblue;
				break;
			case 4:
				flubba = orange;
				break;
			case 5:
				flubba = purple;
				break;
			case 6:
				flubba = red;
				break;
			default:
				flubba = green;
				break;
		}

		currentCheckpoint = startPoint;
		Instantiate(flubba);
	}

	// Used for initialization
	void Start() {
		audio = GetComponent<AudioSource>();
		currentFlubba = GameObject.FindWithTag("Player");
		RespawnPlayer();
	}

	// Called when the player dies or goes out of bounds to respawn them at the latest checkpoint
	public void RespawnPlayer() {
		currentFlubba.transform.position = currentCheckpoint.transform.position;
	}

	// The level boundary which kills the player if they leave its bounds
	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			HandleDeath();
		}
	}

	// Process player death
	public void HandleDeath() {
		audio.clip = deathAudioClip;
		audio.Play();
		deathCount.deathCount++;
		RespawnPlayer();
	}
}
