using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HelperText : MonoBehaviour {

	public Text text;
	
    //set intialize first msg that will be displayed in level1's helper dialogue
	void Start () {
		text.text = "Find your way out of the lab as fast as you can!";
	}

    //method that will set different messages in the helper dialogue
	public void setText (string msg) {
		text.text = msg;
	}
}
