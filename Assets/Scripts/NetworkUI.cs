using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class NetworkUI : NetworkBehaviour
{
    [SerializeField] private Button hostButton;
    [SerializeField] private Button clientButton;
    [SerializeField] private TextMeshProUGUI playersCountText;
    private NetworkVariable<int> playersNum = new(0, NetworkVariableReadPermission.Everyone);


    // Start is called before the first frame update
    private void Awake()
    {
        hostButton.onClick.AddListener(() =>
        {
            TestClientRpc("Hello from the server!");

        });

        clientButton.onClick.AddListener(() =>
        {
            TestServerRpc("Hello from the client!");
        });
    }

    // Update is called once per frame
    private void Update()
    {
        playersCountText.text = "Players: " + playersNum.Value.ToString();
        
        if (!IsServer) return; //count only clients connected

        playersNum.Value = NetworkManager.Singleton.ConnectedClients.Count;
        
    }

    [ClientRpc]
    private void TestClientRpc(FixedString32Bytes msg) //can of course also receive all value types
    {
        
        Debug.Log(msg);
        
    }

    [ServerRpc(RequireOwnership = false)]
    private void TestServerRpc(FixedString32Bytes msg)
    {
        //if (!IsOwner) return;
            Debug.Log(msg);
    }
}
