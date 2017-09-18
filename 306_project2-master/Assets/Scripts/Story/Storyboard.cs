﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Storyboard : MonoBehaviour {

	public Text flubText;
	public Text evilText;

	private int countIntro = 0;

	void Update() {
		// User can either press the "Continue" button or press return to progress through story
		if (Input.GetKeyDown("return")) {
			clickedIntro();
		}
	}

	// Set dialogue for Flubba
	public void setFlubText(string msg) {
		flubText.text = msg;
	}

	// Set dialogue for mysterious evil entity
	public void setEvilText(string msg) {
		evilText.text = msg;
	}

	// Progress through story
	public void clickedIntro() {
		if (countIntro == 0) {
			setFlubText("Flubba: Huh? Where am I?");
			countIntro++;
		} else if (countIntro == 1) {
			setFlubText("");
			setEvilText("Voice: Thank god! You made it!");
			countIntro++;
		} else if (countIntro == 2) {
			setEvilText("Voice: Things were looking pretty hairy for a while back there.");
			countIntro++;
		} else if (countIntro == 3) {
			setEvilText("");
			setFlubText("Flubba: What? Who are you?");
			countIntro++;
		} else if (countIntro == 4) {
			setFlubText("");
			setEvilText("Voice: That doesn't matter right now.");
			countIntro++;
		} else if (countIntro == 5) {
			setEvilText("Voice: Right now you just need to get out of here.");
			countIntro++;
		} else if (countIntro == 6) {
			setEvilText("Voice: Don't worry, I'll help you.");
			countIntro++;
		} else if (countIntro == 7) {
			// Story finished progress to level
			Application.LoadLevel("level1");
		}
	}

	// Bypass story and progress to level
	public void skipped() {
		Application.LoadLevel("level1");
	}
}
