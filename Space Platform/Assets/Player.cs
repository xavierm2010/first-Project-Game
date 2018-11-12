using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public PlayerHealthBar Health;
    public float PVMax = 100;
    private float PV;

	void Start ()
    {
        PV = PVMax;
	}
	
	
	void Update ()
    {
        PV = PV - (1 * Time.deltaTime);
        //Health.fill(PV, PVMax);
	}
}
