using UnityEngine;
using System.Collections;

public class BunsenBurnerController : MonoBehaviour {

    public GameObject firePrefab;
    GameObject fireSpawn;
    GameObject currentFire;
    public bool fireOn;
    private AudioSource audio;

    void Awake()
    {
        //retrieve audio source for the bunsen burner
        audio = GetComponent<AudioSource>();
        //attain child game object for the fire spawn of the bunsen burner
        fireSpawn = this.gameObject.transform.GetChild(0).gameObject;
        //bunsen burner is off by default
        fireOn = false;
    }

    void Start()
    {
        //function is repeated every 2 seconds after the first 3 seconds
        InvokeRepeating("OperateFire", 3, 2F);
    }

    void OperateFire()
    {
        //if the bunsen burner is off, set to be on and instantiate Fire gameobject by spawn
        //also play sound
        if (!fireOn)
        {
            audio.Play();
            currentFire = Instantiate(firePrefab, fireSpawn.transform.position, 
                transform.rotation) as GameObject;
            fireOn = true;
        }
        //if the bunsen burner is on, set to be off and destroy current Fire gameobject
        //also stop sound
        else
        {
            audio.Stop();
            Destroy(currentFire);
            fireOn = false;
        }
    }
}
