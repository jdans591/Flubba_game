using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CoinCount : MonoBehaviour {

	public int coinCount;
	public Text text;

	// Use this for initialization
	void Start () {

		text.text = "Coins:0";
	
	}
	
	// Update is called once per frame
	void Update () {

		text.text = "Coins:" + coinCount.ToString ();
	
	}
}
