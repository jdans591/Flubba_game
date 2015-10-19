using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BioStory : MonoBehaviour {
	
	public Text evilText;
	public Text btnText;
	private int countIntro = 0;

	// Update is called once per frame
	void Update () {
		//user can either press the "Continue" button or press return to progress through story
		if (Input.GetKeyDown("return")){
			clickedIntro();
		}
	}

	//set dialogue for mysterious evil entity
	public void setEvilText(string msg){
		evilText.text = msg;
	}

	//progress through story
	public void clickedIntro(){
		if (countIntro == 0) {
			setEvilText ("Voice: Congratulations, you've escaped from Bohr's chemistry lab.");
			countIntro++;
		} else if (countIntro == 1) {
			setEvilText ("Voice: This is Bohr's biology lab where he spends most of his time. You should find him here.");
			countIntro++;
		} else if (countIntro == 2) {
			setEvilText ("Voice: You're going to have to kill him if you want any chance of escaping.");
			countIntro++;
		} else if (countIntro == 3) {
			//go to next scene of story
			Application.LoadLevel("end_bio");
		}
	}

	//bypass story; go straight to level
	public void skipped(){
		Application.LoadLevel("level3");
	}
}
