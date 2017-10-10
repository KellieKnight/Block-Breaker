using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

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
            rBody.velocity = new Vector2(2f, 8.5f);
        }
	}
}
