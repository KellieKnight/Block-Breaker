﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    float mousePosInBlocks;

    public bool debugPlay = false;

    private Ball ball;

    // Use this for initialization
    void Start () {

        ball = GameObject.FindObjectOfType<Ball>();

    }
	
	// Update is called once per frame
	void Update () {

        if (!debugPlay)
        {
            MoveWithMouse();
        }
        else
        {
            AutoPlay();
            

        }
        
	}

    void AutoPlay()
    {
        
        Vector3 paddlePos = new Vector3(this.transform.position.x, this.transform.position.y, 0f);

        Vector3 ballPos = ball.transform.position;

        paddlePos.x = Mathf.Clamp(ballPos.x, 0.5f, 15.5f);

        this.transform.position = paddlePos;

        print(mousePosInBlocks);
    }

    void MoveWithMouse()
    {
        Vector3 paddlePos = new Vector3(this.transform.position.x, this.transform.position.y, 0f);

        mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;

        paddlePos.x = Mathf.Clamp(mousePosInBlocks, 0.5f, 15.5f);

        this.transform.position = paddlePos;

        print(mousePosInBlocks);
    }
}
