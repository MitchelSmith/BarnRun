using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePool : MonoBehaviour {

    public int obstaclePoolSize = 7;
    public GameObject obstaclePrefab;
    public float spawnRate = 5f;
    public float obstacleMin = 5f;
    public float obstacleMax = 20f;

    private GameObject[] obstacles;
    private Vector2 objectPoolPosition = new Vector2(-15f, -25f);
    private float timeSinceLastSpawned;
    //private float spawnYPosition = -5f;
	private float spawnYPosition = -2f;
    private int currentObstacle = 0;
    private float elapsedSeconds = 0;
	private const int hayBaleScrollingSpeed = 50;

	// Use this for initialization
	void Start ()
    {
        obstacles = new GameObject[obstaclePoolSize];
        for(int i = 0; i < obstaclePoolSize; i++)
        {
            obstacles[i] = (GameObject)Instantiate(obstaclePrefab, objectPoolPosition, Quaternion.identity);
        }

	}
	
	// Update is called once per frame
	void Update ()
    {
		//Ben Added  - for hay bale rotating
		for(int i = 0; i < obstaclePoolSize; i++)
		{
			obstacles [i].transform.Rotate (0f,0f, hayBaleScrollingSpeed * Time.deltaTime);
		}
		//Ben added - end

        timeSinceLastSpawned += Time.deltaTime;

        if(GameControl.instance.gameOver == false && timeSinceLastSpawned >= spawnRate)     //puts spawned obstacles in random positions in front of the player
        {
            timeSinceLastSpawned = 0;
            float spawnXPosition = Random.Range(obstacleMin, obstacleMax);
            obstacles[currentObstacle].transform.position = new Vector2(spawnXPosition, spawnYPosition);
            currentObstacle++;
            if(currentObstacle >= obstaclePoolSize)
            {
                currentObstacle = 0;
            }
        }

        elapsedSeconds += Time.deltaTime;
        if (elapsedSeconds > 10.5)      //makes the obstacles appear faster as time goes on
        {
            if(spawnRate <= 1.75)
            {
                return;
            }
            elapsedSeconds = 0;
            spawnRate -= 0.35f;
        }
    }
}
