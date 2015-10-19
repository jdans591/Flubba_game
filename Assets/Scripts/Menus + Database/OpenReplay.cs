using UnityEngine;
using System.Collections;

public class OpenReplay : MonoBehaviour {

	// Set mode to replay mode
	void Start () {
        PlayerPrefs.SetString("isReplay", "true");
	}
	
}
