using FPSControllerLPFP;
using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KrunkerRoyaleNetworkManager : NetworkManager
{
    [SerializeField]public List<Transform> SpawnPoints;
    [SerializeField] public GameObject SafeZone;
    System.Random r = new System.Random();
    GameObject zone;
    bool zoneExists = false;
    public List<string> playerNamesList = new List<string>();
    public List<FpsControllerLPFP> playerList = new List<FpsControllerLPFP>();

    public override void OnStartServer()
    {
        base.OnStartServer();
    }
    public override void OnServerAddPlayer(NetworkConnection conn)
    {
        Transform start = null;
        switch (numPlayers)
        {
            case 0:
                start = SpawnPoints[0];
                zone = Instantiate(SafeZone);
                NetworkServer.Spawn(zone);

                break;
            case 1:
                start = SpawnPoints[1];
                if (!zoneExists)
                {

                    zoneExists = true;
                }
                break;
            case 2:
                start = SpawnPoints[2];
                break;
            case 3:
                start = SpawnPoints[3];
                break;
        }
        GameObject player = Instantiate(playerPrefab, start.position, start.rotation);
        playerList.Add(player.GetComponent<FpsControllerLPFP>());
        NetworkServer.AddPlayerForConnection(conn, player);
    }

    public override void OnServerDisconnect(NetworkConnection conn)
    {
        // TODO: destroy de gebruikte prefebs hier (bullets, grenades)

        base.OnServerDisconnect(conn);
    }

    public void DoBulletDmgToPlayer(uint netID)
    {
        for (int i = 0; i < playerList.Count; i++)
        {
            if (playerList[i].netId == netID)
            {
                playerList[i].Health -= 5;
            }
        }
    }

    
}
