using TMPro;
using Unity.Services.Lobbies;
using Unity.Services.Lobbies.Models;
using Unity.Services.Relay.Models;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyRoom : MonoBehaviour
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

    // private async void init_Lobby(string name, bool isPrivate)
    // {
    //     string lobbyName = name;
    //     int maxPlayers = 4;
    //     CreateLobbyOptions options = new CreateLobbyOptions();
    //     options.IsPrivate = isPrivate;
    //
    //     Lobby lobby = await LobbyService.Instance.CreateLobbyAsync(lobbyName, maxPlayers, options);
    // }

    public void back()
    {
        SceneManager.LoadScene("PreLobby");
    }

    public void begin()
    {
        SceneManager.LoadScene("Game");
    }
}