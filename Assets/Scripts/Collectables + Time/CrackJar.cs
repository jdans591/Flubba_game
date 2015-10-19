using UnityEngine;
using System.Collections;

public class CrackJar : MonoBehaviour {

	private SpriteRenderer spriteRenderer;
	public Sprite sprite1;
	public Sprite sprite2;

	// Set sprite renderer
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer>(); // we are accessing the SpriteRenderer that is attached to the Gameobject
		if (spriteRenderer.sprite == null) { // if the sprite on spriteRenderer is null then
			spriteRenderer.sprite = sprite1; // set the sprite to sprite1
		}
	}

	void OnTriggerEnter2D(Collider2D collision){
		if (collision.gameObject.tag == "Player") {
			this.gameObject.transform.GetComponent<SpriteRenderer> ().sprite = sprite2;
			Instantiate(sprite2, this.gameObject.transform.position, Quaternion.identity);
		}
	}
	
}
