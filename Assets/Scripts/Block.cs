﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    public AudioClip breakSound;

    public Sprite[] hitSprites;

    public static int blockCount = 0;

    public GameObject sparkle;

    private LevelManager levelManager;
    private int timesHit;

    //private bool isBreakable;



    // Use this for initialization
    void Start () {

        //isBreakable  = (this.tag == "Breakable");

        timesHit = 0;
        levelManager = GameObject.FindObjectOfType<LevelManager>();

        //Keep track of blocks
        //if(isBreakable){
        blockCount++;
        //}
	}
	
	// Update is called once per frame
	void Update () {
		
        

	}

    void OnCollisionEnter2D(Collision2D col)
    {
        
        HandleHits();
    }

    void HandleHits()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;

        if (timesHit >= maxHits)
        {
            AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
            blockCount--;


            Instantiate(sparkle, gameObject.transform.position, Quaternion.identity);

            levelManager.BlockDestroyed();
            Destroy(gameObject);
        }
        else
        {
            LoadSprites();
        }

        
    }

    void LoadSprites()
    {
        //Damaged block sprites start at element 0
        //So the index will be 1 less than times hit
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex])
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
    }

    
}
