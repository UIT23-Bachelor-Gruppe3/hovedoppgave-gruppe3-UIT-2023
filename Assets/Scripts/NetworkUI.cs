using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    // Start is called before the first frame update
    private void Awake()
    {
        //connection = GetComponent<RelayConnector>();

        hostButton.onClick.AddListener(() =>
        {
            //connection.CreateRelay();
            RelayConnector.instance.CreateRelay();
        });

        clientButton.onClick.AddListener(() =>
        {
            //relayConnector.JoinRelay(joinCode);
        });
    }

    // Update is called once per frame
    private void Update()
    {
        playersCountText.text = "Players: " + playersNum.Value.ToString();
        
        if (!IsServer) return; //count only clients connected

        playersNum.Value = NetworkManager.Singleton.ConnectedClients.Count;
        
    }
}
