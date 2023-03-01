using System;
using TMPro;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using Unity.Networking.Transport.Relay;
using Unity.Services.Relay.Models;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lobby : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI lobbyCode;
    RelayConnector relayConnector;
    Allocation allocation;


    private void Start()
    {
        relayConnector = FindObjectOfType<RelayConnector>();
        Debug.Log("joincode" + relayConnector.joinCode);
        lobbyCode.text = relayConnector.joinCode;
    }

    public void back()
    {
        SceneManager.LoadScene("PreLobby");
    }

    public void begin()
    {


        SceneManager.LoadScene("Game");
    }
}