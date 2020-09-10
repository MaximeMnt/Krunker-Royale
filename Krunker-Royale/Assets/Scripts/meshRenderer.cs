using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;


public class meshRenderer : NetworkBehaviour
{
    public GameObject gameObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if (!this.transform.parent.GetComponent<RigidbodyFirstPersonController>().isLocalPlayer)
        //     {
        //         gameObject.GetComponent<Renderer>().enabled = false;
        //     }


        // Renderer[] renderers = GetComponentsInChildren<Renderer>();
        // foreach (var r in renderers)
        // {
        //     // Do something with the renderer here...
        //     r.enabled = false; // like disable it for example. 
        // }
    }
}