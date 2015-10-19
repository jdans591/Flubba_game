using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class ButtonText : MonoBehaviour {

	public Text Btext;

	// Use this for initialization
	void Start () {
		Btext.text = "Next";
	
	}

	public void lastClick(string msg){
		Btext.text = msg;
	}
}

