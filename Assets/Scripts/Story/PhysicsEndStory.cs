using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PhysicsEndStory : MonoBehaviour {

	public Text evilText;

	private int countIntro = 0;

	public void Update() {
		// User can either press the "Continue" button or press return to progress through story
		if (Input.GetKeyDown("return")) {
			clicked();
		}
	}

	// Set dialogue for evil scientist
	void setEvilText(string msg) {
		evilText.text = msg;
	}

	// Progress through story
	public void clicked() {
		if (countIntro == 0) {
			setEvilText("Creator: Flubba, you've been a good minion.");
			countIntro++;
		} else if (countIntro == 1) {
			setEvilText("Creator: I knew when I made you, this day would come.");
			countIntro++;
		} else if (countIntro == 2) {
			setEvilText("Creator: You think you're doing the right thing...");
			countIntro++;
		} else if (countIntro == 3) {
			setEvilText("Creator: but it's too late. You've already done my bidding.");
			countIntro++;
		} else if (countIntro == 4) {
			setEvilText("Creator: Do what you have to do.");
			countIntro++;
		} else if (countIntro == 5) {
			// Story finished; go to level
			Application.LoadLevel("level4");
		}
	}

	// Bypass story; go straight to level
	public void skipped() {
		Application.LoadLevel("level4");
	}
}
