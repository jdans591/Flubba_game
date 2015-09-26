using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerPhysics))]
public class PlayerInput : MonoBehaviour {
    PlayerPhysics controller;

    void Start()
    {
        controller = GetComponent<PlayerPhysics>();
    }
}
