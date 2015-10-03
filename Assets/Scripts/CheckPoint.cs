using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour {

    public LevelManager levelManager;
    private bool isChecked = false;

	// Use this for initialization
	void Start () {
        levelManager = FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player" && !isChecked)
        {
            levelManager.currentCheckpoint = gameObject;
            isChecked = true;
        }
    }
}
