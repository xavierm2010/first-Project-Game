using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ennemi : MonoBehaviour {

    public int PV = 100;
    private int PVtotal;
    public float speed;
    public float damage = 5;
    private Transform target;
    [SerializeField] private HealthBar healthBar;
    private float health;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        PVtotal = PV;
    }

    public void TakeDamage(int damage)
    {
        PV -= damage;
        if(PV <= 0)
        {
            Die();
        }
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        health = (float)PV / PVtotal;
        healthBar.SetSize(health);
    }

    void Die()
    {
        Destroy(gameObject);
    }


    void OnTriggerEnter2D(Collider2D hit)
    {
        Player Player = hit.GetComponent<Player>();
        if (Player != null)
        {
            Player.gotHit(damage);
        }
    }
}
