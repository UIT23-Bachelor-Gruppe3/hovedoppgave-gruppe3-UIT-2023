using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void begin()
    {
        SceneManager.LoadScene("LobbyPre");
    }

    public void exit()
    {
        Application.Quit(0);
    }
}