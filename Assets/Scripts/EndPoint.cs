using UnityEngine;
using System.Collections;

public class EndPoint : MonoBehaviour {

    public DatabaseManager dbManager;
	public PauseMenu pauseMenu;
	public EndMenu endMenu;
	public GameObject endMenuCanvas;
	public AudioClip[] audioClip;
	AudioSource audio;
	public bool isPaused;

	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource> ();
		isPaused = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (isPaused) {
			Time.timeScale = 0f;
		} else {
			Time.timeScale = 1f;
		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Player") {
			PlaySound (0);
			pauseMenu.disabled = true;
			isPaused = true;
			StartCoroutine (Example ());
			endMenu.display ();
			endMenuCanvas.SetActive (true);
            dbManager.PostScore("1", "testPlayer", endMenu.timeText.text);
		}
	}

	void PlaySound (int clip) {
		audio.clip = audioClip [clip];
		audio.Play ();
	}

	IEnumerator Example () {
		yield return new WaitForSeconds (30);
	}
}
