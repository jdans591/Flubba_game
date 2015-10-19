using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CoinCount : MonoBehaviour {

	public int coinCount;
	public Text text;

	// Initializes displayed coin count as 0
	void Start() {
		text.text = "Coins:0";
	}

	// Display number of coins collected in the current level
	void Update() {
		text.text = "Coins:" + coinCount.ToString();
	}
}
