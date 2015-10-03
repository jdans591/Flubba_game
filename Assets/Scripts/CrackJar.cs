using UnityEngine;
using System.Collections;



public class CrackJar : MonoBehaviour {

	private SpriteRenderer spriteRenderer;

	public GameObject obj;

	BoxCollider2D collider;

	public Sprite sprite1;
	public Sprite sprite2;

	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer>(); // we are accessing the SpriteRenderer that is attached to the Gameobject

	}
	
	void OnCollisionEnter2D(Collision2D collision)
    {
		Debug.Log("Test collision");
        if (collision.gameObject.tag == "Player") //if the player collides with jar
        {
			Destroy(obj);
            //collision.gameObject.transform.GetComponent<SpriteRenderer>().sprite = sprite2; 
            //Instantiate(sprite2, collision.gameObject.transform.position, Quaternion.identity); 
        }
	}
	// Update is called once per frame
	void Update () {
		Debug.Log("update");


	}
}
