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
        SceneManager.LoadScene("Game");
    }

    public void exitGame()
    {
        Application.Quit();
    }
}