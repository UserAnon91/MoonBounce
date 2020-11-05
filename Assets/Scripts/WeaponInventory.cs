using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInventory : MonoBehaviour {
    public GameObject weaponOne;
    public GameObject weaponTwo;

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown (KeyCode.Alpha1)) {
            weaponOne.SetActive (true);
            weaponTwo.SetActive (false);

        } else if (Input.GetKeyDown (KeyCode.Alpha2)) {
            weaponTwo.SetActive (true);
            weaponOne.SetActive (false);
        }
    }
}