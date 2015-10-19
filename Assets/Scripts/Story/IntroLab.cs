using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class IntroLab : MonoBehaviour {
	
	public Text text;
	private int count = 0;
	private int countIntro = -1;

	// Use this for initialization
	void Start () {
		setText("\"Knife..\"");

	}
	
	// Update is called once per frame
	void Update () {
		//user can either press the "Continue" button or press return to progress through story
		if (Input.GetKeyDown("return")){
			clicked();
		}
	}

	//set dialogue for shadowed figures
	public void setText(string msg){
		text.text = msg;
	}
	
	//prgress through story
	public void clicked(){
		if (count == 0) {
			setText ("\"Scalpel..\"");
			count++;
		} else if (count == 1) {
			setText ("\"Sponge..\"");
			count++;
		} else if (count == 2) {
			setText ("\"Wait! It's convulsing!\"");
			count++;
		} else if (count == 3) {
			setText ("\"Grab the shotgun! Grab the shotgun!\"");
			count++;
		} else if (count == 4) {
			//go to next scene in story
			Application.LoadLevel ("intro_tutorial2");
		}
		
	}

	//bypass story overlay and go straight to level
	public void skipped(){
		Application.LoadLevel("level1");
	}
}
