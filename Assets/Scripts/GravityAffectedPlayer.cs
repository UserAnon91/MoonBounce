using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (playerControl))]

public class GravityAffectedPlayer : GravityAffectedEntity {
    public GameObject ourCamera;

    public float rotationSpeed = 120.0f;
    // public float translationSpeed = 10.0f;  
    // public float height = 2.0f;             //height from ground level
    private Transform centre; //transform for planet
    private float radius; //calculated radius from collider
    public SphereCollider planetCollider; //collider for planet

    private playerControl ourPlayer;

    //https://forum.unity.com/threads/character-align-to-surface-normal.33987
    void Start () {
        if (planetCollider == null) {
            centre = transform;
            radius = 0;
        } else {
            //consider scale applied to planet transform (assuming uniform, just pick one)
            radius = planetCollider.radius * planetCollider.transform.localScale.y;
            centre = planetCollider.transform;

        }

        ourPlayer = GetComponent<playerControl> ();
        ourPlayer.ourGravityPlayer = this;
        //starting position at north pole
        // transform.position = centre.position + new Vector3(0,radius+height,0);
    }

    public override void FixedUpdate () {
        // base.FixedUpdate ();

        //translate based on input     
        // float inputMag  = Input.GetAxis("Vertical")*translationSpeed*Time.deltaTime;
        // transform.position += transform.forward * inputMag;
        //snap position to radius + height (could also use raycasts)
        // Vector3 targetPosition = transform.position - centre.position;
        // float ratio = (radius + height) / targetPosition.magnitude;
        // targetPosition.Scale( new Vector3(ratio, ratio, ratio) );
        // transform.position = targetPosition + centre.position;
        //calculate planet surface normal                      
        Vector3 surfaceNormal = transform.position - centre.position;
        surfaceNormal.Normalize ();
        //GameObject's heading
        // float headingDeltaAngle = Input.GetAxis("Horizontal") * Time.deltaTime * rotationSpeed;
        // Quaternion headingDelta = Quaternion.AngleAxis(headingDeltaAngle, transform.up);
        //align with surface normal
        transform.rotation = Quaternion.FromToRotation (transform.up, surfaceNormal) * transform.rotation;
        //apply heading rotation
        // transform.rotation = headingDelta * transform.rotation;

    }
    public override void SetGravityObject (GameObject go) {
        base.SetGravityObject (go);
        planetCollider = go.transform.GetComponent<SphereCollider> ();
        radius = planetCollider.radius * planetCollider.transform.localScale.y;
        centre = planetCollider.transform;
    }
}