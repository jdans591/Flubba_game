using UnityEngine;
using System.Collections;

public class Collectables : MonoBehaviour {

	public CoinCount coinCount;
	public TimeControl timeControl;

	void OnTriggerEnter2D(Collider2D other) {

		// If coin collides with the player, the time is reduced by 1 second,
		// the coin is destroyed and the coin count is incremented.	
		if (other.tag == "Player") {
			timeControl.time = timeControl.time - 1;
			TimeControl.coinCollected++;
			coinCount.coinCount++;

			Destroy(gameObject);
		}
	}
}
