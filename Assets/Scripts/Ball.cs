using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public AudioClip bounce;
    private Paddle paddle;
    private Vector3 paddleToBallVector;
    private Rigidbody2D rBody;
    private bool hasStarted;

	// Use this for initialization
	void Start () {
        
        //"this" is the ball
        paddle = GameObject.FindObjectOfType<Paddle>();
        hasStarted = false;
        paddleToBallVector = this.transform.position - paddle.transform.position;
        rBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        if (!hasStarted)
        {
            //Lock ball relative to paddle
            this.transform.position = paddle.transform.position + paddleToBallVector;
        }

        //Wait for left mouse click to launch
        if (Input.GetMouseButton(0))
        {
            hasStarted = true;
            rBody.velocity = new Vector2(2f, 9f);
        }
	}

   

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Add randomness to Velocity to avoid deadlock ball physics
        Vector2 randomV = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));
        rBody.velocity += randomV;

        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
    }
}
