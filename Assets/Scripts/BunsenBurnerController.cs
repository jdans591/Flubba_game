using UnityEngine;
using System.Collections;

public class BunsenBurnerController : MonoBehaviour {

    public GameObject firePrefab;
    GameObject fireSpawn;
    GameObject currentFire;
    public bool fireOn;

    void Awake()
    {
        fireSpawn = this.gameObject.transform.GetChild(0).gameObject;
        fireOn = false;
    }

    void Start()
    {
        InvokeRepeating("OperateFire", 3, 2F);
    }

    void OperateFire()
    {
        if (!fireOn)
        {
            currentFire = Instantiate(firePrefab, fireSpawn.transform.position, 
                transform.rotation) as GameObject;
            fireOn = true;
        }
        else
        {
            Destroy(currentFire);
            fireOn = false;
        }
    }
}
