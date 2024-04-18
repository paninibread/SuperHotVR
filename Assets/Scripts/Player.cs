using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    GameObject basketball;
    Rigidbody ballRb;
    Rigidbody playerRb;

    public float period = 0.0f;

    public float speed = 4f;
    public float rot = 65f;

    public float forceAdjust = 0.05f;

    bool isJumping = false;

    // Start is called before the first frame update
    void Start()
    {
        basketball = transform.GetChild(0).gameObject;
        ballRb = basketball.GetComponent<Rigidbody>();
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //task 1: add scripts to move a player with keyboard inputs 
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += speed * Time.deltaTime * transform.forward;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position += speed * Time.deltaTime * -transform.right;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position += speed * Time.deltaTime * -transform.forward;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += speed * Time.deltaTime * transform.right;
        }

        if(Input.GetKey(KeyCode.E))
        {
            transform.Rotate(new Vector3(0, rot, 0) * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(new Vector3(0, -rot, 0) * Time.deltaTime);
        }

        //task 2: add scripts for player jumping
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }

        if (isJumping)
        {
            playerRb.AddForce(Vector3.up, ForceMode.Impulse);
            ballRb.AddForce(Vector3.up / 5, ForceMode.Impulse);
        }

        //task 3: add scripts to shoot a ball with keyboard inputs
        if (Input.GetKey(KeyCode.F))
        {
             ballRb.AddForce(new Vector3(0f, 45f, 45f) * ballRb.mass * forceAdjust, ForceMode.Impulse);
            // ballRb.velocity = transform.forward * 2f;
        }

        if (Input.GetKey(KeyCode.R))
        {
            Instantiate(basketball, this.transform.position, Quaternion.identity);
            
        }
    }
}
