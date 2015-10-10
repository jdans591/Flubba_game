using UnityEngine;
using System.Collections;

public class LeaderboardPopulator : MonoBehaviour {

    public GameObject TimeList;
	// Use this for initialization
	void Start ()
    {
        string url = "https://microsoft-apiapp72ef49a46b6242d28d294f2cda80c2cf.azurewebsites.net/api/Values/1";
        WWW www = new WWW(url);
        StartCoroutine(WaitForRequest(www));

        if (www.isDone)
        {
            Debug.Log("Fetched: " + www.text);
            JSONObject obj = new JSONObject(www.text);
            for (int i = 0; i < obj.list.Count; i++)
            {
                string key = obj.keys[i];
                Debug.Log(key);
            }
        }
    }

    IEnumerator WaitForRequest(WWW www)
    {
        yield return www;
        // check for errors
        if (www.error == null)
        {
            Debug.Log("WWW Ok!: " + www.text);
            Debug.Log("Fetched: " + www.text);
            JSONObject obj = new JSONObject(www.text);
            for (int i = 0; i < obj.list.Count; i++)
            {
                string name = obj.list[i].list[0].str;
                string time = obj.list[i].list[1].str;

                Debug.Log(name);
                Debug.Log(time);
            }
        }
        else
        {
            Debug.Log("WWW Error: " + www.error);
        }
    }
    //access data (and print it)
    void accessData(JSONObject obj)
    {
        switch (obj.type)
        {
            case JSONObject.Type.OBJECT:
                for (int i = 0; i < obj.list.Count; i++)
                {
                    string key = (string)obj.keys[i];
                    JSONObject j = (JSONObject)obj.list[i];
                    Debug.Log(key);
                    accessData(j);
                }
                break;
            case JSONObject.Type.ARRAY:
                foreach (JSONObject j in obj.list)
                {
                    accessData(j);
                }
                break;
            case JSONObject.Type.STRING:
                Debug.Log(obj.str);
                break;
            case JSONObject.Type.NUMBER:
                Debug.Log(obj.n);
                break;
            case JSONObject.Type.BOOL:
                Debug.Log(obj.b);
                break;
            case JSONObject.Type.NULL:
                Debug.Log("NULL");
                break;

        }
    }
}
