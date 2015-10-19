using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Level1Story : MonoBehaviour {
	
	public Text flubText;
	public Text evilText;
	private int countIntro = 0;
	
	// Update is called once per frame
	void Update () {
		//user can either press the "Continue" button or press return to progress through story
		if (Input.GetKeyDown("return")){
			clickedIntro();
		}
	}

	//set dialogue for Flubba
	public void setFlubText(string msg){
		flubText.text = msg;
	}

	//set dialogue for mysterious evil entity
	public void setEvilText(string msg){
		evilText.text = msg;
	}

	//progress through story
	public void clickedIntro(){
		if (countIntro == 0) {
			setFlubText ("Flubba: What is this place?");
			countIntro++;
		} else if (countIntro == 1) {
			setFlubText ("");
			setEvilText ("Voice: This is Elon Bohr's chemistry lab");
			countIntro++;
		} else if (countIntro == 2) {
			setEvilText ("Voice: He created you to sabotage those who oppose him.");
			countIntro++;
		} else if (countIntro == 3) {
			setEvilText ("");
			setFlubText ("Flubba: Then how come I'm talking to you?");
			countIntro++;
		} else if (countIntro == 4) {
			setFlubText ("");
			setEvilText ("Voice: Because I broke in and freed you after your creation.");
			countIntro++;
		} else if (countIntro == 5) {
			setEvilText ("Voice: Right now there's nothing for you to do but keep moving.");
			countIntro++;
		}else if (countIntro == 6){
			//story finished, progress to level
			Application.LoadLevel("level2");
		}
	}

	//bypass story go straight to level
	public void skipped(){
		Application.LoadLevel("level2");
	}
}
