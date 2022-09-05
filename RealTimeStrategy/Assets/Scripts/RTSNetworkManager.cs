using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class RTSNetworkManager : NetworkManager
{
    [SerializeField] GameObject unitSpawnPrefab;

    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        base.OnServerAddPlayer(conn);

        GameObject unitSpawnerInstance =  Instantiate(
        unitSpawnPrefab,
        conn.identity.transform.position,
        conn.identity.transform.rotation);

        NetworkServer.Spawn(unitSpawnerInstance, conn);

    }
}
