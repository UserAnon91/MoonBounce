using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageableEntity : MonoBehaviour
{
    public int health;

    public void TakeDamage(int damageAmount){
        health -= damageAmount;

        if(health < 0){
            Destroy(this.gameObject);

        }
    }
}
