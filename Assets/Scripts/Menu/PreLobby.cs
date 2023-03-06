using TMPro;
using Unity.Services.Lobbies;
using Unity.Services.Lobbies.Models;
using UnityEngine;
using UnityEngine.SceneManagement;
using Button = UnityEngine.UI.Button;

public class PreLobby : MonoBehaviour
{
    public RelayConnector relayConnector;
    [SerializeField] TextMeshProUGUI lobbyCodeFromJoin;
    [SerializeField] TextMeshProUGUI lobbyName;
    [SerializeField] GameObject createLobbyButtonGO;
    private Lobby lobby;

    private void Start()
    {
        Button createLobbyButton = createLobbyButtonGO.GetComponent<Button>();
        createLobbyButton.onClick.AddListener(createLobby);
    }

    public async void createLobbyRelayAsync()
    {
        await relayConnector.CreateRelay();
        Debug.Log(relayConnector.joinCode);
        SceneManager.LoadScene("Lobby");
    }


    public async void createLobby()
    {
        int maxPlayers = 4;
        CreateLobbyOptions options = new CreateLobbyOptions();
        options.IsPrivate = true;
        lobby = await LobbyService.Instance.CreateLobbyAsync(lobbyName.text, maxPlayers, options);
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