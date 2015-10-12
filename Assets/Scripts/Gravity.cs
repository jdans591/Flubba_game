using UnityEngine;
using System.Collections;

public class Gravity : MonoBehaviour {

	void Start() {
		Physics.gravity = new Vector3(0, -1.0F, 0);
	}
}