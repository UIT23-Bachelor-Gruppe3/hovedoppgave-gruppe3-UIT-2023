using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PreLobby : MonoBehaviour
{
    public RelayConnector relayConnector;
    [SerializeField] TextMeshProUGUI lobbyCodeFromJoin;
    [SerializeField] TextMeshProUGUI lobbyName;

    private void Start()
    {
        // LobbyNames randomName = gameObject.GetComponent<LobbyNames>();
        // Debug.Log(randomName.getRandomName());
        // lobbyName.text = new LobbyNames().getRandomName();
        // lobbyName.text = "apenes";
    }

    public async void createLobby()
    {
        await relayConnector.CreateRelay();
        Debug.Log(relayConnector.joinCode);
        SceneManager.LoadScene("Lobby");
    }

    public void joinLobby()
    {
        Debug.Log(lobbyCodeFromJoin.text);
        relayConnector.JoinRelay(lobbyCodeFromJoin.text);
        SceneManager.LoadScene("Lobby");
    }

    public void back()
    {
        SceneManager.LoadScene("MainMenu");
    }
}