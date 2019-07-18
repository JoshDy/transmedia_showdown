using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Controller2DJoystick))]
public class PlayerJoyStick : MonoBehaviour {

    public Animator anim;
    
    public bool running;
    public bool punch;

    private bool attacking = false; //Stores if the player is attacking
    private float attackTimeout = 0.6f; //Stores the time the player has to wait before attacking again
    private float timeSinceAttack = 0f;

    public SpriteRenderer PlayerSR;
    float accelerationTimeAirborne = .2f;
    float accelerationTimeGrounded = .1f;
    public bool flipX = false;
    float moveSpeed = 4;
    Vector3 velocity;
    float velocityXSmoothing;

    Controller2DJoystick controller;

	// Use this for initialization
	void Start () {
        running = false;

        PlayerSR = GetComponent<SpriteRenderer>(); //Stores what component to flip when the players sprite needs to be flipped
        PlayerSR.flipX = false; //Stores whether or not the players sprite has been flipped
        anim = GetComponent<Animator>();
        controller = GetComponent<Controller2DJoystick>();
        
	}

	// Update is called once per frame
	void Update () {
        CheckForAttack();

        anim.SetBool("Walking", running);
        anim.SetBool("Punching", punch);


        if (controller.collisions.above || controller.collisions.below)
        {
            velocity.y = 0;
        }

        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        const string axis = "Horizontal";

        if (Input.GetKey(KeyCode.D) || Input.GetAxis(axis) > 0.3) //Runs the code below if the player is pressing d
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y); //Moves the player to the right in the game
            PlayerSR.flipX = false;
        }

        if (Input.GetKeyDown(KeyCode.D) || Input.GetAxis(axis) >= 0.3) //Runs the code below if the player holds the key d down
        {
            running = true;
        }

        if (!Input.GetKeyUp(KeyCode.D) || Input.GetAxis(axis) <= 0.2) //Runs the code below if the player is not holding the key d down
        {
            running = false; //Plays the players idle animation
        }

        if (Input.GetKey(KeyCode.A) || Input.GetAxis(axis) < -0.3) //Runs the code below if the player is pressing a
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y); //Moves the player to the left in the game
            PlayerSR.flipX = true; //Flips the players sprite
        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetAxis(axis) < -0.3) //Runs the code below if the player holds the key a down
        {
            running = true; //Plays the players walking animation
        }

        if (Input.GetKeyUp(KeyCode.A) || Input.GetAxis(axis) > -0.3 && Input.GetAxis(axis) < 0.0) //Runs the code below if the player is not holding the key a down
        {
            running = false; //Plays the players idle animation
        }

       
        float targetVelocityX = input.x * moveSpeed;
        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below)?accelerationTimeGrounded:accelerationTimeAirborne);
        controller.Move(velocity * Time.deltaTime);
	}

    void CheckForAttack() //Function for checking if the player is attacking
    {
        if (Input.GetKey(KeyCode.E) && attacking == false || Input.GetAxis("Attack") > 0.3 && attacking == false) //Runs the code below if the player is holding the e key down and attacking is set to false
        {
            attacking = true; //Attacking is set to true
            timeSinceAttack = 0; //Sets the time since the player last attacked to 0
        }

        if (Input.GetKeyDown(KeyCode.E) || Input.GetAxis("Attack") > 0.3) //Runs the code below if the player is holding the e key down
        {
            punch = true; //Plays the players attacking animation
        }

        if (Input.GetKeyUp(KeyCode.E) || Input.GetAxis("Attack") < 0.3) //Runs the code below if the player is not holding the e key down
        {
            punch = false; //Plays the players idle animation
        }

        if (attacking == true && timeSinceAttack <= attackTimeout) //The code below is run if the player is attacking and they have not attacked for over a certain time
        {
            timeSinceAttack += Time.deltaTime; //Make the player wait until they have to attack again
        }

        else
        {
            attacking = false; //The player is not attacking
        }
    }
}
