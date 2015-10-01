using UnityEngine;
using System.Collections;

/**
 * NOTE: Uses basic ray-tracing template from https://github.com/SebLague/2DPlatformer-Tutorial/tree/master/Episode%2005
 */


[RequireComponent(typeof(PlayerPhysics))]
public class PlayerInput : MonoBehaviour 
{
    public float jumpHeight = 4;
    public float timeToJumpApex = .6f;
    float accelerationTimeAirborne = .2f;
    float accelerationTimeGrounded = .1f;
    float moveSpeed = 6;
    float wallSlidingSpeed = 1;

    float gravity;
    float jumpVelocity;
    Vector3 velocity;
    float velocityXSmoothing;

    bool wallJump;
    bool airCharge;

    PlayerPhysics controller;

    void Start() {
		//The controller is what handles our movement in the game world
        controller = GetComponent<PlayerPhysics>();

		//Gravity setup
        gravity = -(2 * jumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
        print("Gravity: " + gravity + "  Jump Velocity: " + jumpVelocity);

        //Player ability setup
        wallJump = false;
        airCharge = true;
    }

	/**
	 * Update is called every frame in order to update the player with the user's input and calculate the next movment to be handled by the PlayerPhysics class.
	 * Move() takes a Vector2 argument for the amount to be moved and carries it out on the player object. While an object is colliding with a surface, the controller.collisions field
	 * will provide information to the type of collision which can be used to test for jump validity, wall jumping etc.
	 */

    void Update() {
        Debug.Log(Input.GetAxisRaw("Horizontal"));
		//Vertical collision detection
        if (controller.collisions.above || controller.collisions.below) {
            velocity.y = 0;
            //If player lands, reset airCharge
            if (controller.collisions.below) {
                airCharge = true;
            }
        }

        //Use side collisions 
        if (controller.collisions.left || controller.collisions.right) {
            if (velocity.y < 0) {
                velocity.y = -wallSlidingSpeed;
                wallJump = true;
            }
        }
        else {
            wallJump = false;
        }

		//Get keyboard input
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

		//Jumping
        if (Input.GetKeyDown(KeyCode.Space)) {
            //On ground
            if (controller.collisions.below) {
                velocity.y = jumpVelocity;
            }
            //Wall jumping
            else if (wallJump && Mathf.Abs(input.x) == 1) {
                //Check that the jump direction is the opposite of the wall that is attached to
                if ((input.x == -1 && controller.collisions.right) || (input.x == 1 && controller.collisions.left)) {
                    velocity.y = jumpVelocity;
                    velocity.x = input.x * moveSpeed;
                }
            }
            //Double jump in air
            else if (airCharge) {
                airCharge = false;
                velocity.y = jumpVelocity;
            }
        }

        float targetVelocityX = input.x * moveSpeed;
		//Player accelerates towards top speed in the direction specified by input
        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below) ? accelerationTimeGrounded : accelerationTimeAirborne);
        //Gravity is applied
		velocity.y += gravity * Time.deltaTime;

		//The controller is given a veloity to move the player by
        controller.Move(velocity * Time.deltaTime);
    }
}