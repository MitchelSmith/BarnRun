using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Ben added - projectile generator
public class ProjectileGen : MonoBehaviour {	
	private float nextSpawn = 0;
	private const int objectPool = 6;
	private Transform[] preFabList = new Transform[objectPool];
	private int currentChild = 0;

	public Transform preFabToSpawn;			
	public float spawnRate = 5f;		//Rate in second
	public float randomDelay = 5f;		//random delay up to (second)
	public float spawnX = 10f;
	//keep projectiles in between middle screen and up
	public float minSpawnY = 0f;		
	public float maxSpawnY = 4f;

	void Start () {
		Transform temp;
		for (int i = 0; i < objectPool; i++) {
			temp = Instantiate (preFabToSpawn, transform.position, Quaternion.identity);
			temp.gameObject.SetActive (false);
			preFabList[i] = temp;
		}
	}

	void FixedUpdate () {
		if (Time.time > nextSpawn) {
			currentChild %= objectPool;
			preFabList [currentChild].position = new Vector3 (spawnX, Random.Range(minSpawnY,maxSpawnY), 0);
			preFabList [currentChild].rotation = Quaternion.identity;
			preFabList[currentChild++].gameObject.SetActive(true);

			nextSpawn = Time.time + spawnRate + Random.Range (0, randomDelay);
		}
	}		
}
