using UnityEngine;
using System.Collections;

public class SwingEnemy : MonoBehaviour {

	public bool goingRight;
	public float currentRotationZ;
	public float newRotationZ;
	public float swingVelocity;

	//variables are initialised before start
	void Awake() {
		goingRight = true;
		swingVelocity = 0;
	}

	// Use this for initialization
	void Start() {
		// Once started repeat the method Swing 
		// The first one after 3 seconds and in 0.02 seconds afterwards continuously
		InvokeRepeating("Swing", 3, 0.02F);
	}

	// Method to cause swinging action
	void Swing() {
		// Get the current z rotation of object in angles
		currentRotationZ = transform.rotation.eulerAngles.z;
		// If the object is swinging to the right
		if (goingRight) {
			// When going down, accelerate the object
			if (currentRotationZ >= 305 && currentRotationZ < 360) {
				Accelerate();
			}
			// When going up, decelerate the object
			if (currentRotationZ < 50 && currentRotationZ >= 0) {
				Decelerate();
			}
			// Once peak angle is reached, velocity hits 0 and direction is changed
			if (currentRotationZ > 50 && currentRotationZ < 60) {
				swingVelocity = 0;
				goingRight = false;
			}
			// New rotation z calculated based on the velocity
			newRotationZ = currentRotationZ + swingVelocity;
			transform.rotation = Quaternion.Euler(0, 0, newRotationZ);
		}
		// Else the object is swinging to the left
		else {
			// When going up, decelerate the object
			if (currentRotationZ >= 310 && currentRotationZ < 360) {
				Decelerate();
			}
			// When going down, accelerate the object
			if (currentRotationZ < 55 && currentRotationZ >= 0) {
				Accelerate();
			}
			// Once peak angle is reached, velocity hits 0 and direction is changed
			if (currentRotationZ < 311 && currentRotationZ > 300) {
				swingVelocity = 0;
				goingRight = true;
			}
			// New rotation z calculated based on the velocity
			newRotationZ = currentRotationZ - swingVelocity;
			transform.rotation = Quaternion.Euler(0, 0, newRotationZ);
		}
	}

	// Simple acceleration of velocity at rate of 0.16
	void Accelerate() {
		swingVelocity = swingVelocity + 0.16f;
	}

	// Simple deceleration of velocity at rate of 0.16
	void Decelerate() {
		swingVelocity = swingVelocity - 0.16f;
	}
}
