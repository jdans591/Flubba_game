using UnityEngine;
using System.Collections;

public class FireController : MonoBehaviour {

    public LevelManager levelManager;

	// Use this for initialization
	void Start () {
        levelManager = FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        //When player comes into collision with fire, player dies
        if (collider.gameObject.tag == "Player")
        {
            levelManager.HandleDeath();
        }
    }
}
