using UnityEngine;
using System.Collections;
using Mirror;
using FPSControllerLPFP;
using System;

// ----- Low Poly FPS Pack Free Version -----
public class BulletScript : NetworkBehaviour {

	[Range(5, 100)]
	[Tooltip("After how long time should the bullet prefab be destroyed?")]
	public float destroyAfter;
	[Tooltip("If enabled the bullet destroys on impact")]
	public bool destroyOnImpact = false;
	[Tooltip("Minimum time after impact that the bullet is destroyed")]
	public float minDestroyTime;
	[Tooltip("Maximum time after impact that the bullet is destroyed")]
	public float maxDestroyTime;

	[SerializeField] KrunkerRoyaleNetworkManager manager;

	[Header("Impact Effect Prefabs")]
	public Transform [] metalImpactPrefabs;

	private void Start () 
	{

		GameObject tmpObject = GameObject.Find("NetworkManager");
		manager = tmpObject.GetComponent<KrunkerRoyaleNetworkManager>();
		//Start destroy timer
		StartCoroutine (DestroyAfter ());
	}

	//If the bullet collides with anything
	private void OnCollisionEnter (Collision collision) 
	{
		//If destroy on impact is false, start 
		//coroutine with random destroy timer
		if (!destroyOnImpact) 
		{
			StartCoroutine (DestroyTimer ());
		}
		//Otherwise, destroy bullet on impact
		else 
		{
			Destroy (gameObject);
		}

		//If bullet collides with "Metal" tag
		if (collision.transform.tag == "Metal") 
		{
			//Instantiate random impact prefab from array
			Instantiate (metalImpactPrefabs [UnityEngine.Random.Range 
				(0, metalImpactPrefabs.Length)], transform.position, 
				Quaternion.LookRotation (collision.contacts [0].normal));
			//Destroy bullet object
			Destroy(gameObject);
		}

		//If bullet collides with "Target" tag
		if (collision.transform.tag == "Target") 
		{
			//Toggle "isHit" on target object
			collision.transform.gameObject.GetComponent
				<TargetScript>().isHit = true;
			//Destroy bullet object
			Destroy(gameObject);
		}
			
		//If bullet collides with "ExplosiveBarrel" tag
		if (collision.transform.tag == "ExplosiveBarrel") 
		{
			//Toggle "explode" on explosive barrel object
			collision.transform.gameObject.GetComponent
				<ExplosiveBarrelScript>().explode = true;
			//Destroy bullet object
			Destroy(gameObject);
		}

		if (collision.transform.tag == "Player")
		{
			if (!collision.transform.gameObject.GetComponent
           <FpsControllerLPFP>().hasAuthority)
            {
                //Destroy bullet object
                Destroy(gameObject);
				CmdHitPlayer(collision.transform.gameObject.GetComponent
					<FpsControllerLPFP>().netId);
			}
			
		}
	}

	[Command]
	private void CmdHitPlayer(uint playerHitId)
    {
		RpcHitPlayer(playerHitId);
	}

	[ClientRpc]
	private void RpcHitPlayer(uint playerHitId)
    {
		NetworkIdentity.spawned[playerHitId].GetComponent<FpsControllerLPFP>().Health -= 5;
    }

    private IEnumerator DestroyTimer () 
	{
		//Wait random time based on min and max values
		yield return new WaitForSeconds
			(UnityEngine.Random.Range(minDestroyTime, maxDestroyTime));
		//Destroy bullet object
		Destroy(gameObject);
	}

	private IEnumerator DestroyAfter () 
	{
		//Wait for set amount of time
		yield return new WaitForSeconds (destroyAfter);
		//Destroy bullet object
		Destroy (gameObject);
	}
}