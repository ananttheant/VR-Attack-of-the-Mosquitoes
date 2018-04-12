using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRStandardAssets.Utils;

public class MosquitoController : MonoBehaviour
{
    //Vr interactive item
    private VRInteractiveItem VrIntItem;

    //rigidbody of the game object
    private Rigidbody rb;

    //flag to check whether this mosquito is moving
    private bool isMoving = true;

    //speed
    public float speed = 0.5f;

    //minimum distance from the player
    public float minDistance = 0.9f;


	// Use this for initialization
	void Awake ()
	{
        //grab this gameobject's VRInteractive Item component
	    VrIntItem = GetComponent<VRInteractiveItem>();

	    rb = GetComponent<Rigidbody>();

        //make the mosquito look at the player
        transform.LookAt(Camera.main.transform.position);
	}
	

    //when our gameobject is enabled 
    void OnEnable()
    {
        VrIntItem.OnClick += HandleClick;
    }


    //when nour game object is disabled
    void OnDisable()
    {
        VrIntItem.OnClick -= HandleClick;
    }

    private void HandleClick()
    {
        if (rb.isKinematic)
        {
            transform.Rotate(new Vector3(0,0,180));

            rb.isKinematic = false;

            isMoving = false;


        }
    }

    // Update is called once per frame
	void Update ()
    {

        //if the isMoving is true, move to the player
	    if (isMoving)
	    {
	        //calculate the distance between player and mosquito
	        float Distance = Vector3.Distance(transform.position, Camera.main.transform.position);

            //check if we reached the player
	        if (Distance <= minDistance)
	        {
	            //stop moving
	            isMoving = false;
	        }
	        else
	        {
	            //keep moving to the player
                //calculate the movement step d= v*t
	            float step = speed * Time.deltaTime;

                //move the step
	            transform.position = Vector3.MoveTowards(transform.position, Camera.main.transform.position, step);
	        }
	    }

	}
}
