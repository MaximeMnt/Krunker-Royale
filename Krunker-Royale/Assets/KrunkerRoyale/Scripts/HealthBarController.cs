using FPSControllerLPFP;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    public Image healthBar;
    public FpsControllerLPFP player;
    public float startHealth;

    private void Update()
    {
        healthBar.fillAmount = player.Health / startHealth;
        Debug.Log("player health: " + player.Health);
        if (player.Health > 70)
        {
            healthBar.color = Color.green;

        }
        else if (player.Health < 70 && player.Health > 40)
        {
            healthBar.color = Color.yellow;
        }
        else if (player.Health < 40)
        {
            healthBar.color = Color.red;
        }
    }
}
