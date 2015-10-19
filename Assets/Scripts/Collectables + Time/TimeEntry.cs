using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeEntry : MonoBehaviour {


    public Text Player;
    public Text Time;
    public string guid;
    public GameObject ProgressCircle;

    // Set the text inside player column
    public void setPlayer(string x)
    {
       
        Player.text = x;
    }

    // Set the text inside time column
    public void setTIme(string y)
    {
        Time.text = y;
    }


    // Triggered upon button click, plays the replay of corresponding entry of leaderboard
    public void playReplay(int currentlevel)
    {
        Debug.Log("timelist guid: " + guid);

        ProgressCircle.SetActive(true);

        //make a get request to database to download corresponding replay file.
        string url = "https://microsoft-apiapp72ef49a46b6242d28d294f2cda80c2cf.azurewebsites.net/api/Replays?fileid="+guid;
        WWW www = new WWW(url);

        Debug.Log(guid);
        StartCoroutine(WaitForRequest(www, currentlevel));

    }

    IEnumerator WaitForRequest(WWW www, int currentlevel)
    {
        yield return www;
      
        // check for errors
        if (www.error == null)
        {
         
           
            //set string to be the replayString
            string str = www.text;
          

            Debug.Log("WaitForRequest called");

        

            string[] delimiters = new string[] { "\\r\\n" };

            string[] split = str.Split(delimiters, System.StringSplitOptions.None);


            str = split[0] + System.Environment.NewLine + split[1] + System.Environment.NewLine;

            




            

            //set the replayString in Playerprefs to the correct string for PlayerInput class to pull from
            PlayerPrefs.SetString("replayString", str);
            //Set replay mode to be active.
            PlayerPrefs.SetInt("isReplay", 1);


            Application.LoadLevel("level" + currentlevel.ToString());

            ProgressCircle.SetActive(false);




        }
        else
        {
            Debug.Log("WWW Error: " + www.error);
            ProgressCircle.SetActive(false);
        }
    }



	



}
