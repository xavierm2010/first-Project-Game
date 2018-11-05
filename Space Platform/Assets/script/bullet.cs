using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {

    public float SpeedBullet = 100f;
    public int damage = 40;
    public Rigidbody2D rb;
    public int time = 100;

	void Start ()
    {
        rb.velocity = transform.right * SpeedBullet;
	}

    void Update()
    {
        if (time <= 1)
        {
            Die();
        }
        else
        {
            time--;
        }
    }

    void OnTriggerEnter2D(Collider2D hit)
    {
        ennemi ennemi = hit.GetComponent<ennemi>();
        if(ennemi != null)
        {
            ennemi.TakeDamage(damage);
        }
        Destroy(gameObject);
    }

    void Die()
    {
        Destroy(gameObject);
    }

}
