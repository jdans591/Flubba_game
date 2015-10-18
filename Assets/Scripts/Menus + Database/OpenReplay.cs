using UnityEngine;
using System.Collections;

public class OpenReplay : MonoBehaviour {

	// Use this for initialization
	void Start () {
        PlayerPrefs.SetString("isReplay", "true");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
