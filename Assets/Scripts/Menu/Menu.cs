using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Networking.Transport;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void begin()
    {
        SceneManager.LoadScene("Lobby");
    }

    public void exitGame()
    {
        Application.Quit();
    }
}