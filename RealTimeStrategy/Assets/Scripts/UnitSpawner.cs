using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using UnityEngine.EventSystems;

public class UnitSpawner : NetworkBehaviour, IPointerClickHandler
{
    [SerializeField] GameObject unitPrefab;
    [SerializeField] Transform unitSpawnPoint;

    #region Server

    [Command]
    void CmdSpawnUnit()
    {
        GameObject unit = Instantiate(
        unitPrefab,
        unitSpawnPoint.position,
        unitSpawnPoint.rotation);

        // 위 생성이 서버에서 일어난 것이므로 Client들에게 이를 전달하고,
        // 해당 unit의 권한을 호출한 client 즉 connectionToClient에 준다.
        NetworkServer.Spawn(unit, connectionToClient);
        //Spawn the given game object on all clients which are ready.
    }

    #endregion


    #region Client

    public void OnPointerClick(PointerEventData eventData) // -> 오브젝트에 대한 클릭
    {
        if (eventData.button != PointerEventData.InputButton.Left) { return; } 

        if(!hasAuthority) { return; };

        CmdSpawnUnit();
    }

    #endregion



}
