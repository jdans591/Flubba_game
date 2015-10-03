using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public GameObject startPoint;
    public GameObject currentCheckpoint;
    public GameObject flubba;

	// Use this for initialization
	void Start () {
        Instantiate(flubba);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void RespawnPlayer()
    {
        Debug.Log("Player respawned");
        flubba.transform.position = currentCheckpoint.transform.position;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        RespawnPlayer();
        Debug.Log("object left the game area");

    }
}
