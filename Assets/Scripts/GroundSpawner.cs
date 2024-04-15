using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public event System.Action OnDifficuilty;
    public int difficulty;
    public GameObject groundTile;
    public int obstacleBlock;
    Vector3 nextSpawnPoint;
    
    

    
   

    public void Spawner()
    {
        GameObject inst = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = inst.transform.GetChild(1).transform.position;
        difficulty++;
        if(difficulty % 25 == 0)
        {
            
            OnDifficuilty?.Invoke();

        }




    }
    void Start()
    {
        for (int i = 0; i < 20; i++)
        {
            obstacleBlock++;
            Spawner();
           
            
        }
    }

    
}
