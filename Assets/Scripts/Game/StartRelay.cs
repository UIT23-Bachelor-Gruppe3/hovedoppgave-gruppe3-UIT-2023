using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartRelay : MonoBehaviour
{
    [SerializeField] RelaySO relaySO;

    private void Start()
    {
        relaySO.StartHost();
    }
}
