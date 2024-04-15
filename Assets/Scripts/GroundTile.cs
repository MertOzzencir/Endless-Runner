using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GroundTile : MonoBehaviour
{

    public GameObject obstaclePrefab;
    public GameObject coinPrefab;
    GroundSpawner spawner;
   

    private void Awake()
    {
        spawner = FindAnyObjectByType<GroundSpawner>();
        spawnCoin();
        if(spawner.obstacleBlock >= 2)
        {
            spawnObstacle();
        }
        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.tag == "Player")
        {
            spawner.Spawner();

            Destroy(gameObject, 2.5f);
        }

    }
    
    public void spawnObstacle()
    {
        int randomIndex = Random.Range(2, 5);
        Vector3 positionOfChild = transform.GetChild(randomIndex).position;
        Instantiate(obstaclePrefab, positionOfChild, Quaternion.identity, transform);
         
    }
    void spawnCoin()
    {
        int amountOfCoinsToSpawn = Random.Range(1, 15);
        for(int i = 0; i < amountOfCoinsToSpawn; i++)
        {
           
            GameObject temp = Instantiate(coinPrefab,transform);
            temp.transform.position = GetPositionFromCollider(GetComponent<Collider>());
            

        }

    }

    Vector3 GetPositionFromCollider(Collider collider)
    {

        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z));
            if(point != collider.ClosestPoint(point))
            {
                 point = GetPositionFromCollider(collider);
                
            }
        point.y = 1;
        return point;

    }
    


}
