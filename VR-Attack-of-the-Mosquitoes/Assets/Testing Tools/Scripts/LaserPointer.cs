using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRStandardAssets.Utils;

namespace MyTools
{


    [RequireComponent(typeof(LineRenderer))]
    public class LaserPointer : MonoBehaviour
    {

        //line renderer component
        private LineRenderer lineRend;

        private Reticle reticle;

        private Vector3[] laserPoints;

        // Use this for initialization
        void Awake()
        {
            //grab component
            lineRend = GetComponent<LineRenderer>();

            reticle = FindObjectOfType<Reticle>();
            if (reticle == null)
            {
                Debug.LogError("no reticle in the scene, add one.");
            }

            //initialize array
            laserPoints=new Vector3[2];

        }

        // Update is called once per frame
        void Update()
        {
            //start and end points of the laser
            laserPoints[0] = transform.position;
            laserPoints[1] = reticle.ReticleTransform.position;

            //set line renderer points
            lineRend.SetPositions(laserPoints);
        }
    }
}
