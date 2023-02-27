using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lobby : MonoBehaviour
{
    private RelayConnector RelayConnector { get; set; }

    private void Awake()
    {
        RelayConnector = FindObjectOfType<RelayConnector>();
    }


    public void createLobby()
    {
        Debug.Log("RelayConnector: " + RelayConnector); // Add this line
        RelayConnector.CreateRelay();
        SceneManager.LoadScene("Game");
    }


    public void joinLobby()
    {
    }

    public void back()
    {
        SceneManager.LoadScene("MainMenu");
    }
}