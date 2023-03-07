using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void begin()
    {
        SceneManager.LoadScene("PreLobby");
    }

    public void exit()
    {
        Application.Quit(0);
    }

    public void settings()
    {
        Debug.Log("going to settings");
    }
}