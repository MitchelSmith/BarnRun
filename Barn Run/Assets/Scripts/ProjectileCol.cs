using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Ben added - Projectile collector 
public class ProjectileCol : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Projectile")
        {
			other.gameObject.SetActive(false);
		}

        if (other.gameObject.tag == "Coin")
        {
            other.gameObject.SetActive(false);
        }  
	}
}
