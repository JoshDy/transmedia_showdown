using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Animator anim; //Stores the set of animations that the character can ultilize

    public float moveSpeed; //Stores the movement speed of the character
    public float jumpHeight; //Stores the jump height

    public Transform groundCheck; //Makes the player check for the ground before jumping again
    public float groundCheckRadius; //Stores the radius before the ground is sensed by the player
    public LayerMask whatIsGround; //Stores what the ground is
    private bool grounded; //Stores if the player is on the ground or not

    private bool attacking = false; //Stores if the player is attacking
    private float attackTimeout = 0.6f; //Stores the time the player has to wait before attacking again
    private float timeSinceAttack = 0f; //Stores the time since the players last attack

    SpriteRenderer PlayerSR; //Stores what sprite the character is using

    // Use this for initialization
    void Start () {
        PlayerSR = GetComponent<SpriteRenderer>(); //Stores what component to flip when the players sprite needs to be flipped
        PlayerSR.flipX = false; //Stores whether or not the players sprite has been flipped
        anim = GetComponent<Animator>(); //Sets which animations the player can utilise

    }

    void FixedUpdate () {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround); //Checks to see if the player has touched the ground and stores that information in this variable
    }

	// Update is called once per frame
	void Update () {

        CheckForAttack(); //Checks to see if the player has started attacking

        if (Input.GetKeyDown (KeyCode.W) && grounded) //Runs the code below if the player presses w and is on the ground
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight); //The player will jump
        }

        if (Input.GetKey(KeyCode.D)) //Runs the code below if the player is pressing d
        {

            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y); //Moves the player to the right in the game
            PlayerSR.flipX = false; //Does not flip the players sprite

        }

        if (Input.GetKeyDown(KeyCode.D)) //Runs the code below if the player holds the key d down
        {

            anim.Play("SpriteWalking"); //Plays the players walking animation

        }

        if (Input.GetKeyUp(KeyCode.D)) //Runs the code below if the player is not holding the key d down
        {

            anim.Play("SpriteIdle"); //Plays the players idle animation

        }

        if (Input.GetKey(KeyCode.A)) //Runs the code below if the player is pressing a
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y); //Moves the player to the left in the game
            PlayerSR.flipX = true; //Flips the players sprite
        }

        if (Input.GetKeyDown(KeyCode.A)) //Runs the code below if the player holds the key a down
        {

            anim.Play("SpriteWalking"); //Plays the players walking animation

        }

        if (Input.GetKeyUp(KeyCode.A)) //Runs the code below if the player is not holding the key a down
        {

            anim.Play("SpriteIdle"); //Plays the players idle animation

        }

    }

    void CheckForAttack() //Function for checking if the player is attacking
    {
        if (Input.GetKeyDown(KeyCode.E) && attacking == false) //Runs the code below if the player is holding the e key down and attacking is set to false
        {
            attacking = true; //Attacking is set to true
            timeSinceAttack = 0; //Sets the time since the player last attacked to 0
        }

        if (Input.GetKey(KeyCode.E)) //Runs the code below if the player is holding the e key down
        {
            anim.Play("SpriteAttack"); //Plays the players attacking animation
        }

        if (Input.GetKeyUp(KeyCode.E)) //Runs the code below if the player is not holding the e key down
        {
            anim.Play("SpriteIdle"); //Plays the players idle animation
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
