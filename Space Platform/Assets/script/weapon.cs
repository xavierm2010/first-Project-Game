using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour {

    public Transform FirePoint;
    public GameObject Bullet;
    private float ShootFrequence = 0f;
    public float ShootDelay = 2f;
	
	void Update ()
    {
		if(Input.GetKey(KeyCode.Space) && ShootFrequence <= 0)
        {
            Shoot();
            ShootFrequence = ShootDelay;
        }

        if(Input.GetKey(KeyCode.Space) && ShootFrequence > 0)
        {
            ShootFrequence = ShootFrequence - Time.deltaTime;
        }
	}

    void Shoot()
    {
        Instantiate(Bullet, FirePoint.position, FirePoint.rotation);
    }
}
