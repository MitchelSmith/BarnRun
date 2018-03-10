 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitObstacle : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Chicken>() != null)      //if player hits the obstacle, the ChickenDied function is called
        {
            GameControl.instance.ChickenDied();
        }
    }

	//Ben Added  - to accomodate dynamic objects collision detection
	private void OnCollisionEnter2D(Collision2D col){
		if (col.collider.GetComponent<Chicken>() != null)      //if player hits the obstacle, the ChickenDied function is called
		{
			GameControl.instance.ChickenDied();

			//Ben added - remove projectile from screen, disable this if collision effect on screen is desired
			if (gameObject.tag == "Projectile") {
				gameObject.SetActive (false);
			}
			//Ben added - end
		}
	}
}
