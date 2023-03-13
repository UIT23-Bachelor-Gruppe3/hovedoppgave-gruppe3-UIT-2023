using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartRelay : MonoBehaviour
{
    [SerializeField] LobbySO lobbySO;

    private void Start()
    {
        lobbySO.StartHost();
    }
}
