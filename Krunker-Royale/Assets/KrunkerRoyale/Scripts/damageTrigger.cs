using FPSControllerLPFP;
using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class damageTrigger : MonoBehaviour
{
    public int DamageRate = 150;
    private int delay;
    private bool inZone = true;

    Collider Playermodel;
    public FpsControllerLPFP Player;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CheckIfPlayerInCircle", 1F, 1F);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void CheckIfPlayerInCircle()
    {
        if (!this.inZone)
        {
            //delay++;
            //if (delay == DamageRate && Player.Health > 0)
            //{
            //    delay = 0;
            //    Playermodel.GetComponent<FpsControllerLPFP>().Health -= 5;

            //}

            if (Player.Health > 0)
            {
                TakeDamage();
            }
        }
        else
        {
            //CancelInvoke("TakeDamage");
        }
    }

    void TakeDamage()
    {
        Playermodel.GetComponent<FpsControllerLPFP>().Health -= 5;
    }

    //[ServerCallback]
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            this.inZone = true;
            Playermodel = other;
        }
    }
    //[ServerCallback]
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            this.inZone = false;
            Playermodel = other;
        }

    }
}