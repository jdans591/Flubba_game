using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RevealStory : MonoBehaviour {
	
	public Text elonText;
	public Text flbText;
	private int countIntro = 0;

	// Update is called once per frame
	public void Update(){
		//user can either press the "Continue" button or press return to progress through story
		if (Input.GetKeyDown("return")){
			clicked();
		}
	}

	//set dialogue for Elon Bohr
	void setElonText(string msg){
		elonText.text = msg;
	}

	//set dialogue for Flubba
	void setFlubText(string msg){
		flbText.text = msg;
	}

	//progress through story
	public void clicked(){
		if (countIntro == 0) {
			setFlubText ("Flubba: What have I done??");
			countIntro++;
		} else if (countIntro == 1) {
			setFlubText ("");
			setElonText ("Elon: This is your creators fault.");
			countIntro++;
		} else if (countIntro == 2) {
			setFlubText ("");
			setElonText ("Elon: You must stop him.");
			countIntro++;
		} else if (countIntro == 3) {
			setElonText("");
			setFlubText ("Flubba: Where can I find him?");
			countIntro++;
		} else if (countIntro == 4) {
			setFlubText ("");
			setElonText ("Elon: He's inside this physics lab, but be careful!");
			countIntro++;
		} else if (countIntro == 5) {
			setFlubText ("");
			setElonText ("Elon: This is our last chance Flubba, good luck.");
			countIntro++;
		} else if (countIntro == 6) {
			//go to next scene of story
			Application.LoadLevel("end_physics");
		}
	}

	//bypass story; go straight to level
	public void skipped(){
		Application.LoadLevel("level4");
	}
}
