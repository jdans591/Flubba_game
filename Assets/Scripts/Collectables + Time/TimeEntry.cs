using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeEntry : MonoBehaviour {

    public Text Player;
    public Text Time;
    public string guid;
    public GameObject ProgressCircle;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    // set the text inside player column
    public void setPlayer(string x)
    {
        Player.text = x;
    }

    // set the tet inside time column
    public void setTIme(string y)
    {
        Time.text = y;
    }


    // triggered upon button click. plays the replay of corresponding entry of leaderboard.
    public void playReplay(int currentlevel)
    {
        Debug.Log("timelist guid: " + guid);

        ProgressCircle.SetActive(true);

        //make a get request to database to download corresponding replay file.
        string url = "https://microsoft-apiapp72ef49a46b6242d28d294f2cda80c2cf.azurewebsites.net/api/Replays?fileid="+guid;
        WWW www = new WWW(url);
        StartCoroutine(WaitForRequest(www, currentlevel));

    }

    IEnumerator WaitForRequest(WWW www, int currentlevel)
    {
        yield return www;
        // check for errors
        if (www.error == null)
        {
            Debug.Log("WWW Ok!: " + www.text);

            ProgressCircle.SetActive(false);
        }
        else
        {
            Debug.Log("WWW Error: " + www.error);
            ProgressCircle.SetActive(false);
        }
    }
}
