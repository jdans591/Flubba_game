using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/**
 * NOTE: Uses basic ray-tracing template from https://github.com/SebLague/2DPlatformer-Tutorial/tree/master/Episode%2005
 */

public class Pipe : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject obj;

    Vector3 originalPosition;
    Vector3 originalVelocity;
    float horizontalRaySpacing;
    float verticalRaySpacing;

    //TimeControl timeControl;

    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        originalPosition = rb.transform.position;
        originalVelocity = new Vector3(0, 0, 0);
        //InvokeRepeating("CreateDrip", 2, 2.0F);
        //InvokeRepeating("DestroyDrip", 4, 2.0F);
    }

    void Update()
    {

    }

    void OnCollisionEnter2D()
    {
        Destroy(obj);
        rb.transform.position = originalPosition;
        rb.transform.rotation = Quaternion.identity;
        rb.velocity = new Vector2(0, 0);
        rb.angularVelocity = 0f;
        Instantiate(obj);
    }

}