using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGravity : MonoBehaviour {
    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void FixedUpdate () {

    }

    void OnTriggerEnter (Collider other) {
        GravityAffectedEntity ge = other.gameObject.GetComponent<GravityAffectedEntity> ();

        ge.SetGravityObject (gameObject);

    }
}