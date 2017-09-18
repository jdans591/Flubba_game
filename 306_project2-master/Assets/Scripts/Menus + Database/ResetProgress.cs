﻿using UnityEngine;
using System.Collections;

public class ResetProgress : MonoBehaviour {

	// Resets player progress from local storage
	void Start() {
		PlayerPrefs.SetString("level2Locked", "true");
		PlayerPrefs.SetString("level3Locked", "true");
		PlayerPrefs.SetString("level4Locked", "true");
		PlayerPrefs.SetFloat("level1Best", 0);
		PlayerPrefs.SetFloat("level2Best", 0);
		PlayerPrefs.SetFloat("level3Best", 0);
		PlayerPrefs.SetFloat("level4Best", 0);
		// Save the updates
		PlayerPrefs.Save();
	}
}
