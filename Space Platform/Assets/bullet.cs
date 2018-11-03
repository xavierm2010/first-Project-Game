using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {

    public float SpeedBullet = 100f;
    public Rigidbody2D rb;

	void Start ()
    {
        rb.velocity = transform.right * SpeedBullet;
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        Destroy(gameObject);
    }

}
