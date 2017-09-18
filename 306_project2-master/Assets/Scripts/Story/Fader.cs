﻿using UnityEngine;
using System.Collections;

public class Fader : MonoBehaviour {

	public float fadeSpeed = 0.5f; // Speed that the screen fades to and from black
	private bool sceneStarting = true; // Whether or not the scene is still fading in

	void Awake() {
		// Set the texture so that it is the the size of the screen and covers it
		GetComponent<GUITexture>().pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);
	}

	void Update() {
		// If the scene is starting call the StartScene function
		if (sceneStarting) {
			StartScene();
		}
	}

	void FadeToClear() {
		// Lerp the colour of the texture between itself and transparent
		GetComponent<GUITexture>().color = Color.Lerp(GetComponent<GUITexture>().color, Color.clear, fadeSpeed * Time.deltaTime);
	}

	void FadeToBlack() {
		// Lerp the colour of the texture between itself and black
		GetComponent<GUITexture>().color = Color.Lerp(GetComponent<GUITexture>().color, Color.black, fadeSpeed * Time.deltaTime);
	}

	void StartScene() {
		// Fade the texture to clear
		FadeToClear();

		// If the texture is almost clear set the colour to clear and disable the GUITexture
		if (GetComponent<GUITexture>().color.a <= 0.05f) {
			GetComponent<GUITexture>().color = Color.clear;
			GetComponent<GUITexture>().enabled = false;

			// The scene is no longer starting
			sceneStarting = false;
		}
	}

	public void EndScene() {
		// Make sure the texture is enabled
		GetComponent<GUITexture>().enabled = true;

		// Start fading towards black
		FadeToBlack();

		// If the screen is almost black then reload the level
		if (GetComponent<GUITexture>().color.a >= 0.95f)
			Application.LoadLevel("level2");
	}
}
