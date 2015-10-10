using UnityEngine;
using System.Collections;
using System;

public class DatabaseManager : MonoBehaviour {

    public void PostScore(string level, string name, string time)
    {
        string url = "https://microsoft-apiapp72ef49a46b6242d28d294f2cda80c2cf.azurewebsites.net/api/Values";
        WWWForm form = new WWWForm();
        form.AddField("level", level);
        form.AddField("name", name);
        form.AddField("time", time);
        WWW www = new WWW(url, form);
        StartCoroutine(WaitForRequest(www));

        Debug.Log(form.data);
    }

    public void GetLeaderboard()
    {

    }

    IEnumerator WaitForRequest(WWW www)
    {
        yield return www;
        // check for errors
        if (www.error == null)
        {
            Debug.Log("WWW Ok!: " + www.data);
        }
        else
        {
            Debug.Log("WWW Error: " + www.error);
        }
    }
}
