﻿using UnityEngine;

public class GameCamera : MonoBehaviour {

	public GameObject camObject;
	public GameObject player;
	public Vector3 updatePosition;
	public float smoothSpeed;

	// Initialise the camera object
	void Start() {
		// Finding the camera by tag
		camObject = GameObject.FindGameObjectWithTag("MainCamera");
		player = GameObject.FindGameObjectWithTag("Player");
	}

	// Update the camera position
	void Update() {
		// Update the position of the camera each frame based off the player position
		updatePosition = new Vector3(player.transform.position.x, player.transform.position.y + 1, camObject.transform.position.z);
		camObject.transform.position = Vector3.Lerp(camObject.transform.position, updatePosition, smoothSpeed * Time.deltaTime);
	}
}
