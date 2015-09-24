using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {
	Rigidbody2D rb;
	public KeyCode jump;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update () {
		float xspeed = Input.GetAxisRaw("Horizontal") * Time.deltaTime;
		float yspeed = rb.velocity.y;

		// jumping
		if (Input.GetKeyDown(jump)) {
			yspeed = 10;
		}

		// update player velocity
		rb.velocity = new Vector2 (500 * xspeed, yspeed);
	}
}
