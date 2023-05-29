using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstacle;
    float timer;
    public float maxTime;
    public float maxY;
    public float minY;
    float randomY;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void InstantiateObstacle()
    {
        randomY = Random.Range(minY, maxY);
        GameObject newObstacle = Instantiate(obstacle); 
        newObstacle.transform.position = new Vector2(transform.position.x, randomY);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= maxTime) 
        {
            InstantiateObstacle();
            timer = 0;
        }
    }
}
