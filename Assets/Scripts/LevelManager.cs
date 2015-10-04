using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public GameObject startPoint;
    public GameObject currentCheckpoint;
    public GameObject flubba;
    private GameObject currentFlubba;

    public DeathCount deathCount;
    public int numberOfDeath;

    void Awake()
    {
        currentCheckpoint = startPoint;
        Instantiate(flubba);
    }

	// Use this for initialization
	void Start () {
        currentFlubba = GameObject.Find("Player(Clone)");
        RespawnPlayer();
        numberOfDeath = 0;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void RespawnPlayer()
    {
        Debug.Log("Player respawned");
        currentFlubba.transform.position = currentCheckpoint.transform.position;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            deathCount.deathCount++;
            RespawnPlayer();
        }
        Debug.Log("object left the game area");
    }
}
