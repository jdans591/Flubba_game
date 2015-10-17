using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeEntry : MonoBehaviour {

    public Text Player;
    public Text Time;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void setPlayer(string x)
    {
        Player.text = x;
    }

    public void setTIme(string y)
    {
        Time.text = y;
    }
}
