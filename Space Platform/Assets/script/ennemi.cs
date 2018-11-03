using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ennemi : MonoBehaviour {

    public int PV = 100;


    public void TakeDamage(int damage)
    {
        PV -= damage;
        if(PV <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
	
}
