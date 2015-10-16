using UnityEngine;
using System.Collections;

public class EndPoint : MonoBehaviour {

	public PauseMenu pauseMenu;
	public EndMenu endMenu;
	public GameObject endMenuCanvas;
	public AudioClip[] audioClip;
    public TimeControl timeControl;
    AudioSource audio;
	public bool isPaused;
    string level;
    float best;

	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource> ();
		isPaused = false;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Player") {


            /*            //16 seconds cutoff to unlock level 2
                        if (Application.loadedLevelName.Equals("level1"))
                        {
                            Debug.Log("Level2Locked should be false now.");
                            PlayerPrefs.SetString("Level2Locked", "false");
                            Debug.Log("Value of level locked now is :" + PlayerPrefs.GetString("Level2Locked"));
                        }
                        //1 minute cutoff to unlock level 3
                        else if ( Application.loadedLevelName.Equals("level2"))
                        {
                            PlayerPrefs.SetString("Level3Locked", "false");
                        }
                        //2 minutes cutoff to unlock level 4
                        else if (Application.loadedLevelName.Equals("level3"))
                        {
                            PlayerPrefs.SetString("Level4Locked", "false");
                        }

                        PlayerPrefs.Save();

            */




            // Update level select GUI to show player progress through each of the 4 different levels
            UpdateProgress();
            

            PlaySound (0);
			pauseMenu.disabled = true;
            endMenu.timeControl.StopTimer();
			endMenu.display ();
			endMenuCanvas.SetActive (true);
		}
	}

    void UpdateProgress() {
        // Get time taken for current level
        float time = timeControl.time;
        // Get current level
        level = Application.loadedLevelName;
        // Set local storage to unlock next level (remove padlock from Level Select GUI) and update best time
        switch (level) {
            case "level1":
                PlayerPrefs.SetString("level2Locked", "false");
                UpdateBest(1, time);
                break;
            case "level2":
                PlayerPrefs.SetString("level3Locked", "false");
                UpdateBest(2, time);
                break;
            case "level3":
                PlayerPrefs.SetString("level4Locked", "false");
                UpdateBest(3, time);
                break;
            case "level4":
                UpdateBest(4, time);
                break;
            default:
                break;
        }
        PlayerPrefs.Save();
    }

    void UpdateBest(int level, float time) {
        best = PlayerPrefs.GetFloat("level" + level.ToString() + "Best");
        if (time < best || best == 0) {
            PlayerPrefs.SetFloat("level" + level.ToString() + "Best", time);
        }
        PlayerPrefs.Save();
    }

    void PlaySound (int clip) {
		audio.clip = audioClip [clip];
		audio.Play ();
	}
}
