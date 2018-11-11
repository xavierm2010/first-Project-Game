using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthBar : MonoBehaviour {

    public Transform cam;
    public Vector3 Offset;
	
	void Update () {
        transform.position = cam.position + Offset;
	}
}
