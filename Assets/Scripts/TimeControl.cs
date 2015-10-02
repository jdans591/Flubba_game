using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimeControl : MonoBehaviour {

    public Text text;
    public float time;

    private float minute;
    private float second;

	// Use this for initialization
	void Start () {
        text.text = "0";
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //FixedUpdate is called once every fixed interval
    void FixedUpdate()
    {
        time = Time.timeSinceLevelLoad;
        second = time;
        if(second >= 60)
        {
            
            minute = Mathf.Floor(time / 60);
            second = time % 60;
        }
        if(time < 60)
        {
            text.text = second.ToString("F2");
            
        } 
        else if(time >= 60)
        {
            text.text = minute.ToString("F0") + " " + ":" + " " + second.ToString("F2");
            
        }
        
    }
}
