using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D hit)
    {
        Player Player = hit.GetComponent<Player>();
        if (Player != null)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
