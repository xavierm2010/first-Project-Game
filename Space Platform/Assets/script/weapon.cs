using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour {

    public Transform FirePoint;
    public GameObject Bullet;
	
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
	}

    void Shoot()
    {
        Instantiate(Bullet, FirePoint.position, FirePoint.rotation);
    }
}
