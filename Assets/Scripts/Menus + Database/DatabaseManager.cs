using UnityEngine;
using System.Collections;
using System;

public class DatabaseManager : MonoBehaviour {

    public GameObject ProgressCircle;

    public void PostScore(string level, string name, string time)
    {
        ProgressCircle.SetActive(true); //turn the loading wheel on

        string url = "https://microsoft-apiapp72ef49a46b6242d28d294f2cda80c2cf.azurewebsites.net/api/Values";
        //create a form to submit with the post request to web api
        WWWForm form = new WWWForm();
        form.AddField("level", level);
        form.AddField("name", name);
        form.AddField("time", time);
        Guid g = Guid.NewGuid();
        form.AddField("guid", g.ToString());

        string url2 = "https://microsoft-apiapp72ef49a46b6242d28d294f2cda80c2cf.azurewebsites.net/api/Replays";
        //create a form to submit with the post request to web api
        WWWForm form2 = new WWWForm();
        form2.AddField("fileid", g.ToString());
        
        form2.AddField("content", PlayerPrefs.GetString("replayString"));

        WWW www = new WWW(url, form); // post request 1
        WWW www2 = new WWW(url2, form2); // post request 2

        StartCoroutine(WaitForRequest(www, www2));
    }

    // post request 1
    IEnumerator WaitForRequest(WWW www, WWW www2)
    {
        yield return www;
        // check for errors
        if (www.error == null)
        {
            //when first request is succesful, begin the next request
            Debug.Log("WWW Ok!: " + www.text);
            StartCoroutine(WaitForRequest2(www2));
        }
        else
        {
            Debug.Log("WWW Error: " + www.error);
            ProgressCircle.SetActive(false);
        }
    }

    // post request 2
    IEnumerator WaitForRequest2(WWW www)
    {
        yield return www;
        // check for errors
        if (www.error == null)
        {
            Debug.Log("WWW Ok!(2): " + www.text);
        }
        else
        {
            Debug.Log("WWW Error(2): " + www.error);
        }
        ProgressCircle.SetActive(false);
    }
}
