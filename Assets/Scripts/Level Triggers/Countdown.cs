using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Countdown : MonoBehaviour {

	public Text text;
	private float time;
	private float delay = 3;

	void Start () {
		text.text = delay.ToString ("F0");
	}

	//Fixed update is called every fixed interval of time
	void FixedUpdate () {
		time = Time.timeSinceLevelLoad;

		if (time > delay) {
			if (time < delay + 1) {
				text.text = "GO!";
			} else {
				text.text = "";
			}
		} else {
			text.text = (Mathf.Ceil (3 - time)).ToString ("F0");
		}
	}
}
