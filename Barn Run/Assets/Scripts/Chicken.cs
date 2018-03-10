using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : MonoBehaviour {

    public float upForce = 750f;			// How high chicken can jump
    public float endForce = 1500f;			// Force that propels character after hitting an obstacle
    public float fallingForce = 300f;		// Gravity bestowed upon character
    public bool isDead = false;				// Boolean to check character alive/dead status
    public AudioClip jump;					// Jumping audio clip
    public float elapsedSeconds;			// How much time passed
    public Sprite originalChicken;
    public Sprite shadesChicken;

    private Rigidbody2D rb2d;				// Character Body
    //private bool isJumping = false;		// Not using unless restricting movement
    //private bool isJumping2 = false;      // Not using unless restricting movement
    private bool endDone = false;			// Boolean of whether the game ends or not
	private Animator animate;				// Character Animation function
    private SpriteRenderer sr;

    /* INITIALIZATION */
    void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();
		animate = GetComponent<Animator>();

        sr = GetComponent<SpriteRenderer>();
        sr.sprite = shadesChicken;

        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = jump;
    }
	
	/* CALLED ONCE PER FRAME */
	void Update ()
    {
        elapsedSeconds += Time.deltaTime;

		if (isDead == false)
        {
            if (Input.GetMouseButtonDown (0) && Time.timeScale == 1)
            {
				/* THE BELOW COMMENTED SECTION RESTRICTS CHARCTER JUMPS
				 * IN GAME.
				 * /

				/*
                if(isJumping == false) 
                {
                    rb2d.velocity = Vector2.zero;
                    rb2d.AddForce(new Vector2(0, upForce));
                    isJumping = true;
                    GetComponent<AudioSource>().Play();
					animate.SetTrigger("Jump");
                }
                else if (isJumping2 == false)
                {
                    rb2d.velocity = Vector2.zero;
                    rb2d.AddForce(new Vector2(0, upForce));
                    isJumping2 = true;
					animate.SetTrigger ("Jump");
                    GetComponent<AudioSource>().Play();
                    elapsedSeconds = 0;
                }
                if(isJumping == true && isJumping2 == true && elapsedSeconds > 1.15)   //after double jumping, allows small jumps until ground is hit
                {
                    rb2d.AddForce(new Vector2(0, fallingForce));
					animate.SetTrigger ("Jump");
                    GetComponent<AudioSource>().Play();
                }
                */

				/* THIS BLOCK OF CODE ALLOWS PLAYERS TO HAVE UNLIMITED
				 * JUMPING IN GAME */
				//animate.SetTrigger ("Jump");
				GetComponent<AudioSource> ().Play ();
				rb2d.velocity = Vector2.zero;
				rb2d.AddForce(new Vector2(0, upForce));
            }
        }
	}

	/* THIS IS A COLLISION FUNCTION */
    private void OnCollisionEnter2D(Collision2D collision)
    {
		/*if(collision.gameObject.tag == "Ground")    // Checks to see if the player is touching the ground
        {                                             // Also not used unless restricting movement
            isJumping = false;
            isJumping2 = false;
        }*/

		// Ben added - collision.gameObject.tag == "Projectile" check
		if((collision.gameObject.tag == "Obstacle" || collision.gameObject.tag == "Projectile" ) && endDone == false)      //Checks to see if the player is touching an obstacle
        {
			
            rb2d.AddForce(new Vector2(0, endForce));
			isDead = true;										// Set to where player cant jump post-mortem
            endDone = true;
			animate.SetTrigger ("Dead");						// Trigger animation for a dead chicken
            rb2d.constraints = RigidbodyConstraints2D.None;
        }
    }
}
