using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BioEndStory : MonoBehaviour {
	
	public Text elonText;
	public Text flbText;
	public Text evilText;
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
			setFlubText ("Flubba: It's over Elon. I'm getting out of this place.");
			countIntro++;
		} else if (countIntro == 1) {
			setFlubText ("");
			setElonText ("Elon: I knew this day would come, ever since your creator went into hiding!");
			countIntro++;
		} else if (countIntro == 2) {
			setElonText ("");
			setFlubText ("Flubba: Don't try and fool me.");
			countIntro++;
		} else if (countIntro == 3) {
			setFlubText ("Flubba: I know it was YOU who created me!");
			countIntro++;

		} else if (countIntro == 4) {
			setFlubText ("");
			setElonText ("Elon: How do you know that? Did the voice inside your head tell you that?!");
			countIntro++;
		} else if (countIntro == 5) {
			setElonText ("");
			setFlubText ("");
			evilText.text = "Voice: Don't listen to him, you need to kill him before he calls for help!";
			countIntro++;
		} else if (countIntro == 6) {
			setFlubText ("");
			evilText.text = "";
			setElonText ("Elon: No, I am not your creator.");
			countIntro++;
		} else if (countIntro == 7) {
			setElonText ("Elon: Your sole purpose is to cripple those who would dare stand up to your creator.");
			countIntro++;
		}else if (countIntro == 8){
			setElonText ("Elon: I have something to show you, meet me in the physics lab...");
			countIntro++;
		}else if (countIntro == 9){
			//story finished - go to level
			Application.LoadLevel("level3");
		}
	}

	//bypass story overlay and go straight to level
	public void skipped(){
		Application.LoadLevel("level3");
	}
}
