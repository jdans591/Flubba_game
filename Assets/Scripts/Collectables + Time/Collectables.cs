using UnityEngine;
using System.Collections;

public class Collectables : MonoBehaviour {

	public CoinCount coinCount;
    public TimeControl timeControl;

	void OnTriggerEnter2D (Collider2D other) {
        // If coin collides with flubba
        if (other.tag == "Player") {
            // Decrement time by 1 second, increment coincollected
            timeControl.time = timeControl.time - 1;
            TimeControl.coinCollected++;
			coinCount.coinCount++;
            // Destory coin object upon collision
			Destroy (gameObject);
		}
	}

}
