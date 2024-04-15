using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float turnSpeed;
    Vector3 horizontalInput;
    Rigidbody rb;
    public bool alive = true;
    GroundSpawner difficulty;
    public float difficuiltyValue;
    public Vector2 speedMinMax;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        difficulty = FindAnyObjectByType<GroundSpawner>();
        difficulty.OnDifficuilty += SetSpeed;
    }
    void Update()
    {
        if (alive)
        {
            
            float xAxis = Input.GetAxisRaw("Horizontal");
            horizontalInput = Vector3.right * xAxis * turnSpeed;

            transform.Translate(transform.forward * speed * Time.deltaTime + horizontalInput);
           
          

            if (transform.position.y < -10)
            {
                StartCoroutine(Die());

            }
           
        }
       
       

    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + transform.forward * speed * Time.fixedDeltaTime + horizontalInput);
    }

    void SetSpeed()
    {
        speed = speed * difficuiltyValue;
        speed = Mathf.Clamp(speed, speedMinMax.x, speedMinMax.y);
        

    }

   

    public IEnumerator Die()
    {
        alive = false;
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene(0);
         
    }
    private void OnDestroy()
    {
        difficulty.OnDifficuilty -= SetSpeed;
    }
}
