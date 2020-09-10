using Mirror.Examples.Basic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPSControllerLPFP
{
    public class camscript : MonoBehaviour
    {
        public GameObject PlayerPrefab;
        // Start is called before the first frame update
        void Start()
        {
            //PlayerPrefab = GameObject.Find("/Player");
        }

        // Update is called once per frame
        void Update()
        {

            if (!PlayerPrefab.GetComponent<FpsControllerLPFP>().isLocalPlayer)
            {
                gameObject.GetComponent<Camera>().enabled = false;
                gameObject.GetComponent<AudioListener>().enabled = false;
                
            }
        }
    }
}