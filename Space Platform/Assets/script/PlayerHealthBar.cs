using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour {

    public Image HealthBar;


    public void fill(float PV, float PVMax)
    {
        HealthBar.fillAmount = PV / PVMax;
    }
}
