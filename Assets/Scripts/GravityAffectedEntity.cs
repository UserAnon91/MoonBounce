using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityAffectedEntity : MonoBehaviour {
    public GameObject planet;
    public Rigidbody ourRigidbody;

    // Start is called before the first frame update
    void Start () {
        ourRigidbody = GetComponent<Rigidbody> ();

    }

    // Update is called once per frame
    public virtual void FixedUpdate () {
        if (planet != null) {
            ourRigidbody.AddForce ((planet.transform.position - transform.position).normalized * 9.81f, ForceMode.Acceleration);

        }
    }

    public virtual void SetGravityObject (GameObject go) {
        planet = go;

    }
}