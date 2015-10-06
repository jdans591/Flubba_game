using UnityEngine;
using System.Collections;

public class CrackJar : MonoBehaviour {

	private SpriteRenderer spriteRenderer;
	
	public Sprite sprite1;
	public Sprite sprite2;

	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer> (); // we are accessing the SpriteRenderer that is attached to the Gameobject
		if (spriteRenderer.sprite == null) { // if the sprite on spriteRenderer is null then
			spriteRenderer.sprite = sprite1; // set the sprite to sprite1
		}
	}

	void OnTriggerEnter2D (Collider2D collision) {
		if (collision.gameObject.tag == "Player") {
			collision.gameObject.transform.GetComponent<SpriteRenderer> ().sprite = sprite2;
			Instantiate (sprite2, collision.gameObject.transform.position, Quaternion.identity);
		}
	}

	// Update is called once per frame
	void Update () {
		Debug.Log ("update");
	}
}
