using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class ButtonText : MonoBehaviour {

	public Text Btext;

	// Used for initialization
	void Start() {
		Btext.text = "Next";
	}

	public void lastClick(string msg) {
		Btext.text = msg;
	}
}

