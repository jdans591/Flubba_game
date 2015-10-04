using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EndMenu : MonoBehaviour {

    public GameObject endMenuCanvas;
    public Text coinText;
    public Text timeText;
    public Text scoreText;
    public CoinCount coinCount;
    public TimeControl time;

    private string finalTime;
    private int numCoin;
    private long finalScore;
    private float finalTimeInFloat; 
    

    // Use this for initialization
    void Start () {
        finalTime = time.text.text;
        numCoin = coinCount.coinCount;

        coinText.text = numCoin.ToString() + "/100";
        timeText.text = finalTime;
        scoreText.text = "10000";
    }
    
    public void backToMainMenu()
    {
        Application.LoadLevel("main_menu");
    }

    public void replayTheStage()
    {
        Application.LoadLevel("basic_level");
    }

    public void continueWithNext()
    {
        Application.LoadLevel("");
    }
}
