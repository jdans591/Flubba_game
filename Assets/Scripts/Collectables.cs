using UnityEngine;
using System.Collections;

public class Collectables : MonoBehaviour {

	public CoinCount coinCount;

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			coinCount.coinCount++;
			Destroy(gameObject);
		}
	}
}
