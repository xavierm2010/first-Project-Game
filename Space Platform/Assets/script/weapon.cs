using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour {

    public Transform FirePoint;
    public GameObject Bullet;
    private float ShootFrequence = 0f;
    public float ShootDelay = 2f;
    public Animator anim;
    bool Fire = false;

    void Update ()
    {
		if(Input.GetKey(KeyCode.Space) && ShootFrequence <= 0)
        {
            Fire = true;
            Shoot();
            ShootFrequence = ShootDelay;
        }

        else if (Input.GetKey(KeyCode.Space) && ShootFrequence > 0)
        {
            Fire = true;
            ShootFrequence = ShootFrequence - Time.deltaTime;
        }
        else if(Input.GetKey(KeyCode.Space) == false)
        {
            Fire = false;
        }

        anim.SetBool("fire", Fire);
    }

    void Shoot()
    {
        Instantiate(Bullet, FirePoint.position, FirePoint.rotation);
    }
}
