using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

	private float elapsedSeconds;		// How many seconds has passed
	//private float elapsedSecondsTotal;     How many Total Seconds has passed

	/*
    private void OnTriggerEnter2D (Collider2D other)
    {
        if (other.GetComponent<Chicken> () != null)     //calls the ChickenScored function to increment score after jumping an obstacle
        {
            GameControl.instance.ChickenScored();
        }
    }
	*/

	// Update is called once per frame
	void Update ()
	{
		elapsedSeconds += Time.deltaTime;
		//elapsedSecondsTotal += Time.deltaTime;

		// Every Second 
		if (elapsedSeconds > .5) {      
			GameControl.instance.ChickenScored ();
			elapsedSeconds = 0;
		}
	}

}
