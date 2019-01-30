using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mele : MonoBehaviour
{
    public Collider2D Mele;
    private float tempAttackMeleMax = 0.5f;
    private float tempAttackMele;
    private int damage = 500;

    private void Start()
    {
        tempAttackMele = tempAttackMeleMax;
    }


    private void Update()
    {

        //attack mele
        if (Input.GetKeyDown(KeyCode.T) && tempAttackMele == tempAttackMeleMax)
        {
            Mele.enabled = true;
        }

        if (tempAttackMele <= 0)
        {
            tempAttackMele = tempAttackMeleMax;
            Mele.enabled = false;
        }
        if (Mele.enabled == true)
        {
            tempAttackMele -= Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D hit)
    {
        ennemi ennemi = hit.GetComponent<ennemi>();
        if (ennemi != null)
        {
            ennemi.TakeDamage(damage);
        }
    }
}
