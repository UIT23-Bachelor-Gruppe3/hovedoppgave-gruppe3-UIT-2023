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
    public RelayConnector relayConnector; //
    private NetworkVariable<int> playersNum = new NetworkVariable<int>(0, NetworkVariableReadPermission.Everyone);

    // Start is called before the first frame update
    private void Awake()
    {
        hostButton.onClick.AddListener(() =>
        {
            relayConnector.CreateRelay();
        });

        clientButton.onClick.AddListener(() =>
        {
            //relayConnector.JoinRelay(joinCode);
        });
    }

    // Update is called once per frame
    private void Update()
    {
        if (!IsServer) return;

        playersNum.Value = NetworkManager.Singleton.ConnectedClients.Count;
        playersCountText.text = "Players: " + playersNum.Value.ToString();
    }
}
