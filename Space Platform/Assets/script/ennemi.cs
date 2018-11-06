using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ennemi : MonoBehaviour {

    public int PV = 100;
    [SerializeField] private HealthBar healthBar;
    private float health;


    public void TakeDamage(int damage)
    {
        PV -= damage;
        if(PV <= 0)
        {
            Die();
        }
    }

    private void Update()
    {
        health = (float)PV / 100;
        healthBar.SetSize(health);
    }

    void Die()
    {
        Destroy(gameObject);
    }
	
}
