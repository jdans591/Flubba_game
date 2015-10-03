using UnityEngine;
using System.Collections;

public class BoundaryTrigger : MonoBehaviour

    
{
    public PlayerInput playerInput;

    void OnTriggerExit2D(Collider2D other)
    {
       
        Debug.Log("object left the game area");
        if(other.gameObject.tag == "Player")
        {
            
            playerInput.deathCount.deathCount++;
            
            other.gameObject.transform.position = new Vector3(0, 0, 0);
        }
    }
}