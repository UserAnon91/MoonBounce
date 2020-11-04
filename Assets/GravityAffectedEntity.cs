using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityAffectedEntity : MonoBehaviour {
    public GameObject gravityAttractedObject;
    public Rigidbody ourRigidbody;

    // Start is called before the first frame update
    void Start () {
        ourRigidbody = GetComponent<Rigidbody> ();

    }

    // Update is called once per frame
    public virtual void FixedUpdate () {
        if (gravityAttractedObject != null) {
            // gravityAttractedObject = null;
            ourRigidbody.AddForce ((gravityAttractedObject.transform.position - transform.position).normalized * 9.81f, ForceMode.Acceleration);

        }

    }

    public virtual void SetGravityObject (GameObject go) {
        gravityAttractedObject = go;

    }
}