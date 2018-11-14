using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour {

    public Image stamina;


    public void fill(float Andurance, float AnduranceMax)
    {
        stamina.fillAmount = Andurance / AnduranceMax;
    }
}
