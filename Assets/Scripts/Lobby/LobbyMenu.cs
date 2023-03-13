using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyMenu : MonoBehaviour
{
    [SerializeField] GameObject beginButtonGO;
    [SerializeField] GameObject backButtonGO;
    [SerializeField] TextMeshProUGUI lobbyName;
    [SerializeField] TextMeshProUGUI lobbyCode;
    [SerializeField] TextMeshProUGUI p1Name;
    [SerializeField] TextMeshProUGUI p2Name;
    [SerializeField] TextMeshProUGUI p3Name;
    [SerializeField] TextMeshProUGUI p4Name;
    [SerializeField] LobbySO lobbySO;

    void Start()
    {
        // set textfields
        lobbyName.text = lobbySO.lobby.Name;
        lobbyCode.text = lobbySO.lobby.LobbyCode;
        p1Name.text = lobbySO.lobby.HostId;

        Button beginButton = beginButtonGO.GetComponent<Button>();
        Button backButton = backButtonGO.GetComponent<Button>();
        beginButton.onClick.AddListener(() => SceneManager.LoadScene("Game"));
        backButton.onClick.AddListener(() => SceneManager.LoadScene("PreLobby"));
    }

}
