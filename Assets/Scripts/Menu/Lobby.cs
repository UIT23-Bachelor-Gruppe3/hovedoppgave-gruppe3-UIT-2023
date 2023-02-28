using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class Lobby : MonoBehaviour
{
    private RelayConnector RelayConnector { get; set; }
    [SerializeField] TextMeshProUGUI joinCode;

    private void Start()
    {
        RelayConnector = FindObjectOfType<RelayConnector>();
    }

    public void createLobby()
    {
        Debug.Log("RelayConnector: " + RelayConnector); // Add this lne
        RelayConnector.CreateRelay();
        SceneManager.LoadScene("Game");
    }

    public void joinLobby()
    {
        RelayConnector.JoinRelay(joinCode.text);
    }

    public void back()
    {
        SceneManager.LoadScene("MainMenu");
    }
}