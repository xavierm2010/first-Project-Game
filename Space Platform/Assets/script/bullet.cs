using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {

    public float SpeedBullet = 100f;
    public int damage = 40;
    public Rigidbody2D rb;
    public int time = 100;
    private SpriteRenderer rendu;
    private CircleCollider2D cercle;
    public ParticleSystem boom;

	void Start ()
    {
        rb.velocity = transform.right * SpeedBullet;
        rendu = GetComponent<SpriteRenderer>();
        cercle = GetComponent<CircleCollider2D>();
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
        rb.velocity = Vector2.zero;
        rendu.enabled = false;
        cercle.enabled = false;
        //boom.Play();
    }

    void Die()
    {
        Destroy(gameObject);
    }

}
