using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    public float turnSpeed = 45;
    private void Update()
    {
        transform.Rotate(0,0, turnSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Obstacle>() != null)
        {
            Destroy(gameObject);
            return;

        }
        if(other.gameObject.tag == "Player")
        {
            GameManager.inst.score++;
            Destroy(gameObject);

        } 

    }

}
