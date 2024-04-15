using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    PlayerMovement player;
    Vector3 offSet;
    Vector3 velocity;
    float smoothTime = 0.1f;

    void Start()
    {
        player = FindAnyObjectByType<PlayerMovement>();
        offSet = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            Vector3 smoothDampVector = player.transform.position + offSet;
            smoothDampVector.x = 0;
            transform.position = Vector3.SmoothDamp(transform.position, smoothDampVector, ref velocity, smoothTime);
        }
        else
        {
            return;
        }
        
    }
}
