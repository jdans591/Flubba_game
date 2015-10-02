using UnityEngine;
using System.Collections;

public class BoundaryTrigger : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D other)
    {
        other.gameObject.transform.position = new Vector3(0, 0, 0);
        Debug.Log("object left the game area");

    }
}