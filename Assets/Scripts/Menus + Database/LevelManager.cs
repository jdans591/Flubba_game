using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	public GameObject startPoint;
	public GameObject flubba;
	public DeathCount deathCount;
	public GameObject currentCheckpoint;
    public AudioClip deathAudioClip;

    private AudioSource audio;
	public GameObject currentFlubba;

	void Awake () {
		currentCheckpoint = startPoint;
		Instantiate (flubba);
	}

	// Use this for initialization
	void Start () {
        audio = GetComponent<AudioSource>();
		currentFlubba = GameObject.Find ("Player(Clone)");
		RespawnPlayer ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void RespawnPlayer () {
		currentFlubba.transform.position = currentCheckpoint.transform.position;
	}

	void OnTriggerExit2D (Collider2D other) {
		if (other.gameObject.tag == "Player") {
			HandleDeath ();
		}
		//Debug.Log ("object left the game area");
	}

	public void HandleDeath () {
        audio.clip = deathAudioClip;
        audio.Play();
		deathCount.deathCount++;
		RespawnPlayer ();
	}
}
