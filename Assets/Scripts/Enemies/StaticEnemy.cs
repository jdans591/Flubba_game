using UnityEngine;
using System.Collections;

public class StaticEnemy : MonoBehaviour {

    public LevelManager levelManager;

	// Use this for initialization
	void Start () {
        levelManager = FindObjectOfType<LevelManager>();
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        //When collision is detected with player, execute death of player
        if (collision.gameObject.tag == "Player")
        {
            levelManager.HandleDeath();
        }
    }
}
