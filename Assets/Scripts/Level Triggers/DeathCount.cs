using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DeathCount : MonoBehaviour {

	public int deathCount;
	public PlayerInput playerInput;
	public Text text;

	// Used for initialization
	void Start () {
		playerInput = GetComponent<PlayerInput> ();
		// Set default deaths
		text.text = "Death:0";
	}

	void Update () {
		// Update the on-screen text with the deathcount
		text.text = "Death:" + deathCount.ToString ();
	}
}
