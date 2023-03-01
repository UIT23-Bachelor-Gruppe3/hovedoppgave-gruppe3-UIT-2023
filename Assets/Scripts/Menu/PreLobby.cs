using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class PreLobby : MonoBehaviour
{
    private static RelayConnector relayConnector;
    [SerializeField] TextMeshProUGUI lobbyCodeFromJoin;

    public void Start()
    {
        relayConnector = RelayConnector.instance;
    }

    public async void createLobby()
    {
        Debug.Log("create lobby gogo");
        await relayConnector.CreateRelay();
        // Debug.Log("hoho");
        // SceneManager.LoadScene("Lobby");
        // lobbyCodeFromCreate.text = relayConnector.joinCode;
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