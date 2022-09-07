using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class RTSPlayer : NetworkBehaviour
{
    [SerializeField] List<Unit> myUnits = new List<Unit>();

    #region Server

    public override void OnStartServer()
    {
        Unit.ServerOnUnitSpawned += ServerHandleUnitSpawned;
        Unit.ServerOnUnitDespawned += ServerHandleUnitDespawned;
    }

    public override void OnStopServer()
    {
        Unit.ServerOnUnitSpawned -= ServerHandleUnitSpawned;
        Unit.ServerOnUnitDespawned -= ServerHandleUnitDespawned;
    }

    void ServerHandleUnitSpawned(Unit unit)
    {
        if (unit.connectionToClient.connectionId != connectionToClient.connectionId) { return; }
        myUnits.Add(unit);
    }

    void ServerHandleUnitDespawned(Unit unit)
    {
        if (unit.connectionToClient.connectionId != connectionToClient.connectionId) { return; }
        myUnits.Remove(unit);
    }

    #endregion


    #region Client

    public override void OnStartClient()
    {
        if (!isClientOnly) { return; }

        Unit.AuthorityOnUnitSpawned += AuthorityHandleUnitSpawned;
        Unit.AuthorityOnUnitDespawned += AuthorityHandleUnitDespawned;
    }

    public override void OnStopClient()
    {
        if (!isClientOnly) { return; }

        Unit.AuthorityOnUnitSpawned -= AuthorityHandleUnitSpawned;
        Unit.AuthorityOnUnitDespawned -= AuthorityHandleUnitDespawned;
    }

    void AuthorityHandleUnitSpawned(Unit unit)
    {
        if (!hasAuthority) { return; }
        myUnits.Add(unit);
    }

    void AuthorityHandleUnitDespawned(Unit unit)
    {
        if (!hasAuthority) { return; }
        myUnits.Remove(unit);
    }


    #endregion
}
