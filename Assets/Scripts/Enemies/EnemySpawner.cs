using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFSW.QC;
using Unity.Netcode;

public class EnemySpawner : NetworkBehaviour
{
    [SerializeField] private Transform enemyPrefab;
    [Command]
    private void spawnEnemy()
    {
        if (!IsServer) return;
        Transform enemyTransform = Instantiate(enemyPrefab);
        enemyTransform.GetComponent<NetworkObject>().Spawn(true);
    }
}
