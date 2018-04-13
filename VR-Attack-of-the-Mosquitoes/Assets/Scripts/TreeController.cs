﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeController : MonoBehaviour {


    //min and max value of scale
    public float minScale = 0.7f;

    public float maxScale = 2.5f;




	// Use this for initialization
	void Start () {

        //make all the trees to come to ground
        //gameObject.transform.position= new Vector3(transform.position.x, 0 ,transform.position.z);


        //obtain a random scale
	    //float scale = Random.Range(minScale, maxScale);

        //change scale
	    //transform.localScale *= scale;

        //random rotation value
	    float rotationY = Random.Range(0, 360);

        //change rotation
        transform.Rotate(0,rotationY,0,Space.World);


	}
}
