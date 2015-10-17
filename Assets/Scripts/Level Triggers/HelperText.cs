using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HelperText : MonoBehaviour {

	public Text text;
	
	void Start () {
		text.text = "Find your way out of the lab as fast as you can!";
	}

	public void setText (string msg) {
		text.text = msg;
	}
}
