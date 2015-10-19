using UnityEngine;
using UnityEngine.UI;

public class EndMenu : MonoBehaviour {

	public Canvas endMenuCanvas;
	public GameObject jackpotCanvas;
	public Text coinText;
	public Text timeText;
	public Text playerName;
	public Text coinsCollectedText;
	public Text bestTimeText;
	public CoinCount coinCount;
	public TimeControl timeControl;
	public DatabaseManager dbManager;

    public Button replay;
    public Button continued;
    public Button submit;


	private string finalTime;
	private int numCoin;
	private long finalScore;
	private float finalTimeInFloat;
	private GameObject[] coins;

	// Time benchmarks for different rankings
	public float[,] benchmark = new float[3, 4] { { 90, 120, 180, 300 }, { 20, 50, 90, 60 }, { 15, 35, 45, 20 } };

	void Start() {
		coins = GameObject.FindGameObjectsWithTag("Coin");

        if(PlayerPrefs.GetInt("isReplay") == 1)
        {
            
            submit.interactable = false;
        }
	}

	// Check if player unlocks a jackpot
	public void display() {
		finalTime = timeControl.text.text;
		numCoin = coinCount.coinCount;

		int jackpotMoney = AttemptForJackpot(); // Check for jackpot winnings

		if (jackpotMoney > 0) {
			// If jackpot has occurred, display the jackpot canvas and add jackpot money to numcoin
			jackpotCanvas.SetActive(true);
			numCoin += jackpotMoney;
		}

		// Display number of coins collected for that level and total coins in wallet
		coinsCollectedText.text = "+" + numCoin.ToString();
		coinText.text = PlayerPrefs.GetInt("coinCount").ToString();

		timeText.text = finalTime;
		GetBestTime();
	}
    
    // Changes current focus to specified scene (find scene by number under file -> Build Settings in Unity)
    public void ChangeToScene(string sceneToChangeTo)
    {
        Application.LoadLevel(sceneToChangeTo);
    }
    
    // Return to level select screen
    public void continueWithNext () {
		Application.LoadLevel ("level_select");
	}

    public void uploadScore(string level)
    {
        dbManager.PostScore(level, playerName.text, timeText.text); //Post score to database
    }

    public void OpenReplay()
    {
        PlayerPrefs.SetInt("isReplay", 1);//set replay status to true.
        PlayerPrefs.Save();
        Application.LoadLevel(Application.loadedLevelName);
    }

 
    
  
	public void backToMainMenu() {
		Application.LoadLevel("main_menu");
	}





	void GetBestTime() {
		string best;
		string currentLevel = Application.loadedLevelName;
		// Check which level is currently in play
		switch (currentLevel) {
			case "level1":
				best = BestToString(PlayerPrefs.GetFloat("level1Best"));
				// Check that a best time has been set
				if (PlayerPrefs.GetFloat("level1Best") != 0) {
					bestTimeText.text = best;
				}
				break;
			case "level2":
				best = BestToString(PlayerPrefs.GetFloat("level2Best"));
				// Check that a best time has been set
				if (PlayerPrefs.GetFloat("level2Best") != 0) {
					bestTimeText.text = best;
				}
				break;
			case "level3":
				best = BestToString(PlayerPrefs.GetFloat("level3Best"));
				// Check that a best time has been set
				if (PlayerPrefs.GetFloat("level3Best") != 0) {
					bestTimeText.text = best;
				}
				break;
			case "level4":
				best = BestToString(PlayerPrefs.GetFloat("level4Best"));
				// Check that a best time has been set
				if (PlayerPrefs.GetFloat("level4Best") != 0) {
					bestTimeText.text = best;
				}
				break;
			default:
				break;
		}
	}

	// Converts best time taken (float) for input into a string representation of that time
	string BestToString(float bestFloat) {
		int bestMins = (int)bestFloat / 60;
		string bestSecs = (bestFloat % 60).ToString();
		bestSecs = bestSecs.Substring(0, 4);
		string bestString = bestMins + ":" + bestSecs;
		return bestString;
	}

	// Returns a reward(coins) by chance.
	int AttemptForJackpot() {
		int randomNumber = Random.Range(1, 101); // Generate a random number between 1 and 100.
		float probability = 0; // Initialise a value which will determine the success of a jackpot.
		int level = 1; // Initialise the current level value.

		string currentScene = Application.loadedLevelName; // Identify the current level

		switch (currentScene) {
			case "level1":
				level = 1;
				break;
			case "level2":
				level = 2;
				break;
			case "level3":
				level = 3;
				break;
			case "level4":
				level = 4;
				break;
			default:
				break;
		}

		float recordtime = timeControl.time;

		// Assign higer values for probability the faster the player completed the level
		if (recordtime <= benchmark[2, level - 1]) {
			probability = 75;
		} else if (recordtime <= benchmark[1, level - 1]) {
			probability = 50;
		} else {
			probability = 10;
		}

		// If randomNumber generated is within probability range, jackpot is fired.
		if (randomNumber < probability) {
			int randomPrizeMoney = Random.Range(100, 1000); // Generate a random number between 100 and 1000.

			// Update total coincount
			int total = PlayerPrefs.GetInt("coinCount");
			total += randomPrizeMoney;

			// Write the new value back to the player prefs
			PlayerPrefs.SetInt("coinCount", total);

			return randomPrizeMoney;
		}
		return 0;
	}
}
