using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Storyboard : MonoBehaviour {

	public Text text;
	private int count = 0;
	ButtonText contButton;

	// Use this for initialization
	void Start () {
		setText("Start");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setText(string msg){
		text.text = msg;
	}

	public void clicked(){
		if (count == 0) {
			setText ("First chapter.");
			count++;
		} else if (count == 1) {
			setText ("Second chapter");
			count++;
		} else if (count == 2) {
			setText ("Third chapter");
			//contButton.lastClick("Play");
			count++;
		} else if (count == 3) {
			Application.LoadLevel(3);
		}
	}
}
