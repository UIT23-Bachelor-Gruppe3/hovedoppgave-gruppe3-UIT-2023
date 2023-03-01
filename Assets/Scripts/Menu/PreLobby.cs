using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class PreLobby : MonoBehaviour
{
    public RelayConnector relayConnector;
    [SerializeField] TextMeshProUGUI lobbyCodeFromJoin;


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