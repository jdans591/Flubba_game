using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerPhysics))]
public class EnemyController : MonoBehaviour
{
    float jumpHeight = 3f;
    float timeToJumpApex = .4f;
    float accelerationTimeGrounded = .08f;
    float moveSpeed = 5;
    float wallSlidingSpeed = 1;
	float dir = 1;

    float gravity;
    Vector3 velocity;
    float velocityXSmoothing;

    private bool canMove;
    private float delay;


    public AudioClip[] audioClip;

    PlayerPhysics controller;
    AudioSource audio;


    /**Initialisation */
    void Start()
    {
        //The controller is what handles our movement in the game world
        controller = GetComponent<PlayerPhysics>();

        audio = GetComponent<AudioSource>();

        //Gravity setup
        gravity = -(2 * jumpHeight) / Mathf.Pow(timeToJumpApex, 2);
	    }

    /**
	 * Update is called every frame in order to update the player with the user's input and calculate the next movment to be handled by the PlayerPhysics class.
	 * Move() takes a Vector2 argument for the amount to be moved and carries it out on the player object. While an object is colliding with a surface, the controller.collisions field
	 * will provide information to the type of collision which can be used to test for jump validity, wall jumping etc.
	 */
    void Update()
    {
        // This if statement check whether the game is paused or not.
        if (Time.timeScale != 0f)
        {

            // The current definition of a vertical wall is a platform with at least approx 75 degrees of elevation from horizontal. 

            //Vertical collision detection. If the player touches the ground or ceiling set vertical velocity to zero.
            if (TouchingGround() || TouchingCeiling())
            {
                velocity.y = 0;
            }

			if (velocity.x == 0) {
				Debug.Log("Speed");
				velocity.x = moveSpeed * dir;
			}

			if (controller.collisions.right && velocity.x == 5) {
				Debug.Log("Right");
                velocity.x = -4;
                dir = -1;
            }
            else if (controller.collisions.left && velocity.x == -4) {
				Debug.Log("Left");
				velocity.x = 6;
                dir = 1;
            }
            //Gravity is applied
            velocity.y += gravity * Time.deltaTime;

			Debug.Log(velocity.x);
            //The controller is given a veloity to move the player by
            controller.Move(velocity * Time.deltaTime);
        }
    }

    //#################
    // Helper funcitons
    //#################


    //Helper function to check if the object is touching the ground.
    bool TouchingGround()
    {
        return (controller.collisions.below);
    }

    //Helper function to check if the object is touching either the left or the right side walls.
    bool TouchingWall()
    {
        return (controller.collisions.left || controller.collisions.right);
    }

    //Helper function to check if the object is touching the right hand side wall.
    bool TouchingRightWall()
    {
        return (controller.collisions.right);
    }

    //Helper function to check if the object is touching the left hand side wall.
    bool TouchingLeftWall()
    {
        return (controller.collisions.left);
    }

    //Helper function to check if the object is touching the ceiling.
    bool TouchingCeiling()
    {
        return (controller.collisions.above);
    }

    void PlaySound(int clip)
    {
        audio.clip = audioClip[clip];
        audio.Play();
    }
}
