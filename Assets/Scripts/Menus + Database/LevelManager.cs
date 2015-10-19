using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	public GameObject startPoint;
	public DeathCount deathCount;
	public GameObject currentCheckpoint;
	public AudioClip deathAudioClip;

	private AudioSource audio;
	public GameObject currentFlubba;
	public GameObject green;
	public GameObject lightblue;
	public GameObject blue;
	public GameObject red;
	public GameObject orange;
	public GameObject purple;

	private GameObject flubba;

	// Set Flubba skins
	void Awake() {
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

	// Respawn player to last saved checkpoint
	public void RespawnPlayer() {
		currentFlubba.transform.position = currentCheckpoint.transform.position;
	}

	// When player escapes level boundary execute death
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
