using UnityEngine;
using System.Collections;

public class GameCamera : MonoBehaviour {
    public GameObject camObject;
    public GameObject player;
    public Vector3 updatePosition;
    public float smoothSpeed;
 
	// Initialise the camera object
	void Start () {
        camObject = GameObject.FindGameObjectWithTag("MainCamera");
    }
 
    // Update the camera position
    void Update () {
        updatePosition = new Vector3(player.transform.position.x, player.transform.position.y, camObject.transform.position.z);
        camObject.transform.position = Vector3.Lerp(camObject.transform.position, updatePosition, smoothSpeed * Time.deltaTime);
    }
}
