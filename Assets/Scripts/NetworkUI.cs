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
    //public RelayConnector connection; //
    private NetworkVariable<int> playersNum = new(0, NetworkVariableReadPermission.Everyone);
    private string joinCode = "Nada";


    // Start is called before the first frame update
    private void Awake()
    {
        //connection = GetComponent<RelayConnector>();

        hostButton.onClick.AddListener(() =>
        {
            //connection.CreateRelay();
            RelayConnector.instance.CreateRelay();
            TestClientRpc();

        });

        clientButton.onClick.AddListener(() =>
        {
            //relayConnector.JoinRelay(joinCode);
            //RelayConnector.instance.JoinRelay(joinCode);
            TestServerRpc(joinCode);
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
    private void TestClientRpc() //can of course also receive all value types
    {
        joinCode = RelayConnector.instance.joinCode;
        Debug.Log("ClientRpc " + joinCode);
        
        //Debug.Log("TestClientRpc" + OwnerClientId);
    }

    [ServerRpc]
    private void TestServerRpc(string code)
    {
        Debug.Log("ServerRpc " + code);
        RelayConnector.instance.JoinRelay(code);
    }
}
