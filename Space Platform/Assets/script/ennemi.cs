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

    private bool follow;
    public Transform PlayerCheck;
    private float CheckRadius = 30f;
    public LayerMask WhatIsPlayer;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        PVtotal = PV;
    }

    public void TakeDamage(int Damage)
    {
        PV -= Damage;
        if(PV <= 0)
        {
            Die();
        }
    }

    void FixedUpdate()
    {
        follow = Physics2D.OverlapCircle(PlayerCheck.position, CheckRadius, WhatIsPlayer);
    }

    void Update()
    {
        if(follow == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
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
