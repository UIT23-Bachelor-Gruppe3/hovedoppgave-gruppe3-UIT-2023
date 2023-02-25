using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFSW.QC;
using Unity.Netcode;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform enemyPrefab;
    [Command]
    private void spawnEnemy()
    {
        Transform enemyTransform = Instantiate(enemyPrefab);
        enemyTransform.GetComponent<NetworkObject>().Spawn(true);
    }
}
