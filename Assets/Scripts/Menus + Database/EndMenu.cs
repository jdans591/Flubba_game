using UnityEngine;
using UnityEngine.UI;

public class EndMenu : MonoBehaviour {

	public GameObject endMenuCanvas;
    public GameObject jackpotCanvas;
	public Text coinText;
	public Text timeText;
    public Text playerName;
    public Text coinsCollectedText;
    public Text bestTimeText;
    public CoinCount coinCount;
	public TimeControl timeControl;
    public DatabaseManager dbManager;

    private string finalTime;
	private int numCoin;
	private long finalScore;
	private float finalTimeInFloat;
    private GameObject[] coins;

    public float[,] benchmark = new float[3, 4] { { 90, 120, 180, 300 }, { 20, 50, 90, 60 }, { 15, 35, 45, 20 } };

    void Start() {
        coins = GameObject.FindGameObjectsWithTag("Coin");
    }

	public void display () {
		finalTime = timeControl.text.text;
		numCoin = coinCount.coinCount;

        int jackpotMoney = AttemptForJackpot(); //check for jackpot winnings

        if (jackpotMoney > 0)
        {
            //if jackpot has occured, display the jackpot canvas and add jackpot money to numcoin
            jackpotCanvas.SetActive(true);
            numCoin += jackpotMoney;
        }

        //coinText.text = numCoin.ToString () + "/" + coins.Length.ToString();
        // Display number of coins collected for that level and total coins in wallet
        coinsCollectedText.text = "+" + numCoin.ToString();
        coinText.text = PlayerPrefs.GetInt("coinCount").ToString();

        timeText.text = finalTime;
        GetBestTime();
    }
    
	public void backToMainMenu () {
		Application.LoadLevel ("main_menu");
	}

    // Changes current focus to specified scene (find scene by number under file -> Build Settings in Unity)
    public void ChangeToScene(string sceneToChangeTo)
    {
        Application.LoadLevel(sceneToChangeTo);
    }

    public void continueWithNext () {
		Application.LoadLevel ("level_select");
	}

    public void uploadScore(string level)
    {
        dbManager.PostScore(level, playerName.text, timeText.text); //Post score to database
    }

    public void OpenReplay()
    {
        PlayerPrefs.SetInt("isReplay", 1);
        Application.LoadLevel(Application.loadedLevelName);
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
        bestSecs = bestSecs.Substring(0, 5);
        string bestString = bestMins + ":" + bestSecs;
        return bestString;
    }

    // Returns a reward(coins) by chance.
    int AttemptForJackpot()
    {
        int randomNumber = Random.Range(1, 101); //generate a random number between 1 and 100.
        float probability = 0; //initialise a value which will determine the success of a jackpot.
        int level = 1; //initialise the current level value.

        string currentScene = Application.loadedLevelName; // identify the current level

        switch (currentScene)
        {
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

        //assign higer values for probability the faster the player completed the level
        if (recordtime <= benchmark[2, level - 1])
        {
            probability = 75; 
        } else if (recordtime <= benchmark[1, level - 1])
        {
            probability = 50; 
        } else
        {
            probability = 10;
        }

        //if randomNumber generated is within probability range, jackpot is fired.
        if (randomNumber < probability)
        {
            Debug.Log("JACKPOT!");
            int randomPrizeMoney = Random.Range(100, 1000); //generate a random number between 100 and 1000.

            //update total coincount
            int total = PlayerPrefs.GetInt("coinCount");
            total += randomPrizeMoney;

            //Write the new value back to the player prefs
            PlayerPrefs.SetInt("coinCount", total);

            return randomPrizeMoney;
        }

        return 0;
    }

}
