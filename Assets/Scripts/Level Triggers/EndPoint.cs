using UnityEngine;
using System.Collections;
using System.Text;

public class EndPoint : MonoBehaviour {

	public PauseMenu pauseMenu;
	public EndMenu endMenu;
	public GameObject endMenuCanvas;
	public AudioClip[] audioClip;
	public TimeControl timeControl;
	public PlayerInput playerInput;
	public bool isPaused;
	public string replayString = "";

	AudioSource audio;
	string level;
	float best;

	// Used for initialization
	void Start() {
		audio = GetComponent<AudioSource>();
		isPaused = false;

        //initialise replayString to blank
        replayString = "";
    }

	void OnTriggerEnter2D(Collider2D other) {
		// When flubba reaches end of level.
		if (other.tag == "Player") {

			// Update level select GUI to show player progress through each of the 4 different levels
			UpdateProgress();

			PlaySound(0); // Play SFX
			pauseMenu.disabled = true; // Disable pausing of the game via esc button press
			UpdateCoinCount(endMenu.coinCount.coinCount);

			endMenu.timeControl.StopTimer(); // Stop the timer
			endMenu.display();
			endMenuCanvas.SetActive(true); // Display the end screen

			other.gameObject.SetActive(false); // Disable the player to remove it from the screen


            //Create the replay string to send to database.
            if (PlayerPrefs.GetInt("isReplay") == 1) // if it's a replay
            {

            } else //make replay string only if the current mode is not replay mode.
            {
                MakeReplayString();
            }

            

            //if isReplay is set to true, set it back to false
            if(PlayerPrefs.GetInt("isReplay") == 1)
            {
                PlayerPrefs.SetInt("isReplay", 0);
                PlayerPrefs.Save();
            }
            

			// Create the replay string to send to database.
			MakeReplayString();

			// If isReplay is set to true, set it back to false
			if (PlayerPrefs.GetInt("isReplay") == 1) {
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


    //Create the replayString to send to the database.
    void MakeReplayString()
    {
        //Reset playerprefs replayString
        PlayerPrefs.SetString("replayString", "");



        StringBuilder builder = new StringBuilder();
        builder.Append(Application.loadedLevelName + System.Environment.NewLine);

        Debug.Log("currentPosition length is : " + PlayerInput.currentPosition.Count);

        //Append each frame positions to make a single string.
        for (int i = 0; i < PlayerInput.currentPosition.Count; i++)
        {

            builder.Append(PlayerInput.currentPosition[i].x + "," + PlayerInput.currentPosition[i].y + "," + PlayerInput.currentPosition[i].z + "," + PlayerInput.currentPosition[i].w + ";");




        }

        string replayString = builder.ToString();

        replayString = replayString + System.Environment.NewLine;

        PlayerPrefs.SetString("replayString", replayString);

        PlayerPrefs.Save();

    }

    // Adds the coin amount to the players total coins
    void UpdateCoinCount(int coins) {
		int total = PlayerPrefs.GetInt("coinCount");
		total += coins;

		//Write the new value back to the player prefs
		PlayerPrefs.SetInt("coinCount", total);
	}

	// Play given sound clip
	void PlaySound(int clip) {
		audio.clip = audioClip[clip];
		audio.Play();
	}

	
}
