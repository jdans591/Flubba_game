using UnityEngine;
using System.Collections;

public class Gravity : MonoBehaviour {

	// Sets gravity behavior
	void Start() {
		Physics.gravity = new Vector3(0, -1.0F, 0);
	}
}
