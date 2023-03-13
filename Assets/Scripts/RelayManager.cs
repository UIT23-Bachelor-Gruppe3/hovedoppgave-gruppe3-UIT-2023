using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class RelayManager : ScriptableObject
{
    public bool isSignedIn;
    public bool isInitialized;
    private void Awake()
    {
        Debug.Log("awake");
    }

}
