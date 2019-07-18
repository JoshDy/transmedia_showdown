using UnityEngine;

public class PlayerController2 : MonoBehaviour {

    public Animator anim2; //Stores the set of animations that the character can ultilize

    public float moveSpeed2; //Stores the movement speed of the character
    public float jumpHeight2; //Stores the jump height 

    public Transform groundCheck2; //Makes the player check for the ground before jumping again
    public float groundCheckRadius2; //Stores the radius before the ground is sensed by the player
    public LayerMask whatIsGround2; //Stores what the ground is
    private bool grounded2; //Stores if the player is on the ground or not

    private bool attacking = false; //Stores if the player is attacking
    private float attackTimeout = 1f; //Stores the time the player has to wait before attacking again
    private float timeSinceAttack = 0f; //Stores the time since the players last attack

    SpriteRenderer PlayerSR; //Stores what sprite the character is using

    // Use this for initialization
    void Start () {

        PlayerSR = GetComponent<SpriteRenderer>(); //Stores what component to flip when the players sprite needs to be flipped
        PlayerSR.flipX = true; //Stores whether or not the players sprite has been flipped
        anim2 = GetComponent<Animator>(); //Sets which animations the player can utilise

    }

    void FixedUpdate()
    {
        grounded2 = Physics2D.OverlapCircle(groundCheck2.position, groundCheckRadius2, whatIsGround2); //Checks to see if the player has touched the ground and stores that information in this variable
    }

    // Update is called once per frame
    void Update () {

        CheckForAttack(); //Checks to see if the player has started attacking

        if (Input.GetKeyDown(KeyCode.I) && grounded2) //Runs the code below if the player presses i and is on the ground
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight2); //The player will jump
        }

        if (Input.GetKey(KeyCode.L)) //Runs the code below if the player is pressing l
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed2, GetComponent<Rigidbody2D>().velocity.y); //Moves the player to the right in the game
            PlayerSR.flipX = false; //Does not flip the players sprite
        }

        if (Input.GetKeyDown(KeyCode.L)) //Runs the code below if the player holds the key l down
        {

            anim2.Play("SpriteWalking2"); //Plays the players walking animation

        }

        if (Input.GetKeyUp(KeyCode.L)) //Runs the code below if the player is not holding the key l down
        {

            anim2.Play("SpriteIdle2"); //Plays the players idle animation

        }

        if (Input.GetKey(KeyCode.J)) //Runs the code below if the player is pressing j
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed2, GetComponent<Rigidbody2D>().velocity.y); //Moves the player to the left in the game
            PlayerSR.flipX = true; //Flips the players sprite
        }

        if (Input.GetKeyDown(KeyCode.J)) //Runs the code below if the player holds the key j down
        {

            anim2.Play("SpriteWalking2"); //Plays the players walking animation

        }

        if (Input.GetKeyUp(KeyCode.J)) //Runs the code below if the player is not holding the key j down
        {

            anim2.Play("SpriteIdle2"); //Plays the players idle animation

        }

    }

    void CheckForAttack() //Function for checking if the player is attacking
    {
        if (Input.GetKeyDown(KeyCode.O) && attacking == false) //Runs the code below if the player is holding the o key down and attacking is set to false
        { 
            attacking = true; //Attacking is set to true
            timeSinceAttack = 0; //Sets the time since the player last attacked to 0
        }

        if (Input.GetKeyDown(KeyCode.O)) //Runs the code below if the player is holding the o key down
        {
            anim2.Play("SpriteAttack2"); //Plays the players attacking animation
        }

        if (Input.GetKeyUp(KeyCode.O)) //Runs the code below if the player is not holding the o key down
        {
            anim2.Play("SpriteIdle2"); //Plays the players idle animation
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
