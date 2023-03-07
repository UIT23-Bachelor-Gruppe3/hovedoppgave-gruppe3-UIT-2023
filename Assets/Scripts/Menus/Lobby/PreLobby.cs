using System;
using TMPro;
using Unity.Services.Lobbies;
using Unity.Services.Lobbies.Models;
using UnityEngine;
using UnityEngine.SceneManagement;
using Button = UnityEngine.UI.Button;

public class PreLobby : MonoBehaviour
{
    // public RelayConnector relayConnector;
    // [SerializeField] TextMeshProUGUI lobbyCodeFromJoin;
    // [SerializeField] TextMeshProUGUI lobbyName;
    [SerializeField] GameObject createLobbyButtonGO;
    private Lobby lobby;

    private void Start()
    {
        Button createLobbyButton = createLobbyButtonGO.GetComponent<Button>();
        createLobbyButton.onClick.AddListener(createLobby);
    }

    // public async void createLobbyRelayAsync()
    // {
    //     await relayConnector.CreateRelay();
    //     Debug.Log(relayConnector.joinCode);
    //     SceneManager.LoadScene("Lobby");
    // }


    private async void createLobby()
    {
        try
        {
            string lobbyName = "lobbyName";
            int maxPlayers = 4;
            CreateLobbyOptions options = new CreateLobbyOptions();
            options.IsPrivate = true;
            lobby = await LobbyService.Instance.CreateLobbyAsync(lobbyName, maxPlayers, options);
            Debug.Log("Lobby created");
            Debug.Log("Created at date: " + lobby.Created);
            Debug.Log("Lobby name: " + lobby.Name);
            Debug.Log("Lobby ID: " + lobby.Id);
            Debug.Log("Lobby code: " + lobby.LobbyCode);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    // public void joinLobby()
    // {
    //     Debug.Log(lobbyCodeFromJoin.text);
    //     relayConnector.JoinRelay(lobbyCodeFromJoin.text);
    //     SceneManager.LoadScene("Lobby");
    // }

    public void back()
    {
        SceneManager.LoadScene("MainMenu");
    }
}