using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using Unity.Networking.Transport.Relay;
using Unity.Services.Relay.Models;
using UnityEngine;

public class InitRelay : MonoBehaviour
{
    Allocation allocation;
    RelayConnector relayConnector;

    void Start()
    {
        relayConnector = FindObjectOfType<RelayConnector>();
        allocation = relayConnector.allocation;
        RelayServerData relayServerData = new RelayServerData(allocation, "dtls");
        NetworkManager.Singleton.GetComponent<UnityTransport>().SetRelayServerData(relayServerData);
        NetworkManager.Singleton.StartHost();
    }
}