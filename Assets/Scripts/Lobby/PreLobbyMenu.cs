using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Button = UnityEngine.UI.Button;

public class PreLobbyMenu : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI lobbyNameInput;
    [SerializeField] TextMeshProUGUI lobbyCodeInput;
    [SerializeField] TextMeshProUGUI playerName;
    [SerializeField] GameObject createLobbyButtonGO;
    [SerializeField] GameObject joinLobbyButtonGO;
    [SerializeField] LobbySO lobbySO;

    private void Start()
    {
        Button createLobbyButton = createLobbyButtonGO.GetComponent<Button>();
        Button joinLobbyButton = joinLobbyButtonGO.GetComponent<Button>();

        // Create lobby and relay on begin-button press
        createLobbyButton.onClick.AddListener(() =>
        {
            lobbySO.CreateLobbyAsync(lobbyNameInput.text, playerName.text);
        }

        );
        joinLobbyButton.onClick.AddListener(() => lobbySO.JoinLobbyAsync(lobbyCodeInput.text));
    }

    public void back()
    {
        SceneManager.LoadScene("MainMenu");
    }
}