using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour {

    private Image HealthBar;
    public float PVMax = 100;
    private float PV;

    void Start ()
    {
        HealthBar = GetComponent<Image>();
        PV = PVMax;
	}
	
	void Update()
    {
        PV = PV - (5 * Time.deltaTime);
        HealthBar.fillAmount = PV / PVMax;
    }
}
