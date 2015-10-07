using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Pipe : MonoBehaviour {
	Rigidbody2D rb;
	public GameObject obj;

	Vector3 originalPosition;
	Vector3 originalVelocity;
	float horizontalRaySpacing;
	float verticalRaySpacing;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		originalPosition = rb.transform.position;
		originalVelocity = new Vector3 (0, 0, 0);
		//InvokeRepeating("CreateDrip", 2, 2.0F);
		//InvokeRepeating("DestroyDrip", 4, 2.0F);
	}

	void OnCollisionEnter2D () {
		Destroy (obj);
		rb.transform.position = originalPosition;
		rb.transform.rotation = Quaternion.identity;
		rb.velocity = new Vector2 (0, 0);
		rb.angularVelocity = 0f;
		Instantiate (obj);
	}
}