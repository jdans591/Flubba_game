using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LeaderboardPopulator : MonoBehaviour {
    
    public CanvasLevel CL1;
    public CanvasLevel CL2;
    public CanvasLevel CL3;
    public CanvasLevel CL4;
    public List<CanvasLevel> CList;

    public TimeEntry[,] TList2D;
    

    // Use this for initialization
    void Start()
    {
        CList = new List<CanvasLevel>();
        TList2D = new TimeEntry[8, 4];

        CList.Add(CL1);
        CList.Add(CL2);
        CList.Add(CL3);
        CList.Add(CL4);

        for (int i = 0; i < 1; i++)    //change i to 4 later
        {
            for (int j = 0; j < 8; j++)
            {
                TList2D[j, i] = CList[i].TList[j];
            }
        }

        string url = "https://microsoft-apiapp72ef49a46b6242d28d294f2cda80c2cf.azurewebsites.net/api/Values/1";
        WWW www = new WWW(url);
        StartCoroutine(WaitForRequest(www));
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

            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < obj.list.Count; j++)
                {
                    string name = obj.list[j].list[0].str;
                    string time = obj.list[j].list[1].str;

                    TList2D[j, i].Player.text = name;
                    TList2D[j, i].Time.text = time;
                    //TList[i].setPlayer(name);
                    //Debug.Log(time);
                }
            }
        }
        else
        {
            Debug.Log("WWW Error: " + www.error);
        }
    }
}
