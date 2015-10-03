using UnityEngine;
using System.Collections;

/**
 * NOTE: Uses basic ray-tracing template from https://github.com/SebLague/2DPlatformer-Tutorial/tree/master/Episode%2005
 */


[RequireComponent(typeof(PlayerPhysics))]
public class PlayerInput : MonoBehaviour
{

    float jumpHeight = 3f;
    float timeToJumpApex = .4f;
    float accelerationTimeAirborne = .35f; //
    float accelerationTimeGrounded = .08f;
    float moveSpeed = 6;
    float wallSlidingSpeed = 1;

    float gravity;
    float jumpVelocity;
    Vector3 velocity;
    float velocityXSmoothing;

    bool wallJump;
    int airCharge;

    private bool playerCanMove;
    private float delay;

    public DeathCount deathCount;
    public int numberOfDeath;

    PlayerPhysics controller;


    /**Initialisation */
    void Start()
    {
        //The controller is what handles our movement in the game world
        controller = GetComponent<PlayerPhysics>();

        //Gravity setup
        gravity = -(2 * jumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;

        //Player ability setup
        wallJump = false;
        airCharge = 0;



        playerCanMove = false;
        delay = 3;
        numberOfDeath = 0;
    }

    /**
	 * Update is called every frame in order to update the player with the user's input and calculate the next movment to be handled by the PlayerPhysics class.
	 * Move() takes a Vector2 argument for the amount to be moved and carries it out on the player object. While an object is colliding with a surface, the controller.collisions field
	 * will provide information to the type of collision which can be used to test for jump validity, wall jumping etc.
	 */
    void Update()
    {
        //Delay for 3 seconds before the player can move.
        if (playerCanMove == false)
        {
            if (Time.timeSinceLevelLoad > delay)
            {

                playerCanMove = true;

            }
            else
            {
                return;
            }
        }
        // This if statement check whether the game is paused or not.
        if (Time.timeScale != 0f)
        {

            // The current definition of a vertical wall is a platform with at least approx 75 degrees of elevation from horizontal. 

            //Vertical collision detection. If the player touches the ground or ceiling set vertical velocity to zero.
            if (TouchingGround() || TouchingCeiling())
            {
                velocity.y = 0;
                //If player lands, reset airCharge
                if (TouchingGround())
                {
                    airCharge = 1;
                }
            }

            //Use side collisions. Player will slide down the wall at a constant value. 
            if (TouchingWall())
            {
                if (velocity.y < 0)
                {
                    velocity.y = -wallSlidingSpeed;
                    wallJump = true;
                }
            }
            else
            {
                wallJump = false;
            }

            //Get keyboard input
            Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

            //Ignore left button if the object is on the right wall, and ignore right button if the object is on the left wall. 
            //Also, if the down button is pressed while the object is on a wall, it will slightly move the object off it 
            //and drop the object down. (With the raycasting code the current definition of a wall is at least approx 75 degrees
            //from horizontal). 
            if (TouchingWall() && !TouchingGround())
            {
                if (TouchingRightWall())
                {
                    if (input.y == -1)
                    {
                        velocity.x = -moveSpeed / 100;
                    }
                    if (input.x == -1)
                    {
                        input.x = 0;
                    }
                }
                else if (TouchingLeftWall())
                {
                    if (input.y == -1)
                    {
                        velocity.x = moveSpeed / 100;
                    }
                    if (input.x == 1)
                    {
                        input.x = 0;
                    }
                }
            }

            //When the jump button is pressed.
            if (Input.GetKeyDown(KeyCode.Space))
            { //Simply jump if the object is on the ground. 
                if (TouchingGround())
                {
                    velocity.y = jumpVelocity;
                }//If the object is touching a wall, jump in the opposite direction.
                else if (TouchingWall())
                {
                    if (TouchingRightWall())
                    {
                        velocity.y = jumpVelocity;
                        velocity.x = -moveSpeed * (float)1.5;
                    }
                    else if (TouchingLeftWall())
                    {
                        velocity.y = jumpVelocity;
                        velocity.x = moveSpeed * (float)1.5;
                    }
                }
                else if (airCharge == 1)
                {
                    velocity.y = jumpVelocity;
                    velocity.x = moveSpeed * input.x;
                    airCharge--;
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
}