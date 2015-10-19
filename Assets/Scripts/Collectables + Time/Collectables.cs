using UnityEngine;
using System.Collections;

public class Collectables : MonoBehaviour {

	public CoinCount coinCount;
    public TimeControl timeControl;

	void OnTriggerEnter2D (Collider2D other) {
        //if coin collides with flubba
        if (other.tag == "Player") {
            //decrement time by 1 second, increment coincollected
            timeControl.time = timeControl.time - 1;
            TimeControl.coinCollected++;

			coinCount.coinCount++;
            //destory coin object upon collision
			Destroy (gameObject);
		}
	}
}
