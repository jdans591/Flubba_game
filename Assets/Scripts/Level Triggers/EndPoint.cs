using UnityEngine;
using System.Collections;

public class EndPoint : MonoBehaviour {

	public PauseMenu pauseMenu;
	public EndMenu endMenu;
	public GameObject endMenuCanvas;
	public AudioClip[] audioClip;
    public TimeControl timeControl;
    public PlayerInput playerInput;
    AudioSource audio;
	public bool isPaused;
    string level;
    float best;

    public string replayString = "";

	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource> ();
		isPaused = false;
	}

	void OnTriggerEnter2D (Collider2D other) {
        //when flubba reaches end of level.
        if (other.tag == "Player") { 

        // Update level select GUI to show player progress through each of the 4 different levels
        UpdateProgress();

            PlaySound (0); //play sfx
			pauseMenu.disabled = true; //disable pausing of the game via esc button press
            UpdateCoinCount(endMenu.coinCount.coinCount);

            endMenu.timeControl.StopTimer(); //stop the timer
			endMenu.display ();
			endMenuCanvas.SetActive (true); //displayed the end screen

            other.gameObject.SetActive(false); //disable flubba to prevent further action and disappear into pipe

            //Create the replay string to send to database.
            MakeReplayString();

            //if isReplay is set to true, set it back to false
            if(PlayerPrefs.GetInt("isReplay") == 1)
            {
                PlayerPrefs.SetInt("isReplay", 0);
            }
            
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

    //Adds the coin amount to the players total coins
    void UpdateCoinCount(int coins) {
        int total = PlayerPrefs.GetInt("coinCount");
        total += coins;

        //Write the new value back to the player prefs
        PlayerPrefs.SetInt("coinCount", total);
    }

    //play given sound clip
    void PlaySound (int clip) {
		audio.clip = audioClip [clip];
		audio.Play ();
	}


    //Create the replayString to send to the database.
    void MakeReplayString()
    {
        for(int i = 0; i < PlayerInput.movementInputs.Count; i++)
        {
            replayString = replayString + PlayerInput.movementInputs[i].x + "," + PlayerInput.movementInputs[i].y + "," + PlayerInput.movementInputs[i].z + ";";

        }

        replayString = replayString + System.Environment.NewLine;

        for(int i = 0; i < PlayerInput.jumpInputs.Count; i++)
        {
            replayString = replayString + PlayerInput.jumpInputs[i].x + "," + PlayerInput.jumpInputs[i].y + ";";
        }

        replayString = Application.loadedLevelName + System.Environment.NewLine + replayString;


        PlayerPrefs.SetString("replayString", replayString);


        Debug.Log("Finished making replay string.");
    }
}
