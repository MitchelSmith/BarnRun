using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour {

    private Rigidbody2D rb2d;

	// Use this for initialization
	void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        rb2d.velocity = new Vector2(GameControl.instance.scrollSpeed, 0);   //sets speed of background

        if (GameControl.instance.gameOver == true)      //if the game is over the background stops moving
        {
            rb2d.velocity = Vector2.zero;
        }
	}
}
