using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class UnitMovement : NetworkBehaviour
{
    [SerializeField] NavMeshAgent navMeshAgent;

    #region Server

    [Command]
    public void CMDMove(Vector3 position)
    {
        // position 값을 navMesh 상에서 찾지 못했을 경우 return
        // SamplePosition은 현재 오브젝트의 위치에서 가장 가까운 점을 찾아준다.
        // 즉 현 위치에서 입력받은 position으로 가는 길이 없다 -> return 
        if (!NavMesh.SamplePosition(position, out NavMeshHit hit, 1f, NavMesh.AllAreas)) { return; }
        navMeshAgent.SetDestination(position);
    }

    #endregion


    #region Client

    #endregion


}
