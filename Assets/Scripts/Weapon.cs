using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int damage;

    public float fireRate;
    private float remainingTimeTillFire = 0f;

    public GameObject weaponTrail;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(remainingTimeTillFire > 0){
            remainingTimeTillFire -= Time.deltaTime;

        }

        if(Input.GetMouseButton(0)){
            if(remainingTimeTillFire <= 0){
                FireWeapon();

                remainingTimeTillFire = fireRate;

            }
        }
        
    }

    protected virtual void FireWeapon(){

    }
}
