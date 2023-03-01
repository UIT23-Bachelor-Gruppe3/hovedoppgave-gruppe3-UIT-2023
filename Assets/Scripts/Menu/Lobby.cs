using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lobby : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI lobbyCode;
    RelayConnector relayConnector;

    private void Start()
    {
        relayConnector = FindObjectOfType<RelayConnector>();
        Debug.Log("joincode" + relayConnector.joinCode);
        lobbyCode.text = relayConnector.joinCode;
    }

    public void back()
    {
        Debug.Log("back to LobbyPre");
        SceneManager.LoadScene("LobbyPre");
    }

    public void begin()
    {
        SceneManager.LoadScene("Game");
    }
}