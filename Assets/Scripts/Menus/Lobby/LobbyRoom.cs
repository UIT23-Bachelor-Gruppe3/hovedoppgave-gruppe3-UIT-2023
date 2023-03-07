using System;
using Unity.Services.Core;
using Unity.Services.Lobbies;
using Unity.Services.Lobbies.Models;
using UnityEngine;
using UnityEngine.UI;

public class LobbyRoom : MonoBehaviour
{
    private Lobby lobby;

    // private void Awake()
    // {
    //     initMe();
    // }
    [SerializeField] GameObject createLobbyButtonGO;


    private void Start()
    {
        Button createLobbyButton = createLobbyButtonGO.GetComponent<Button>();
        createLobbyButton.onClick.AddListener(createLobby);
    }

    private async void initMe()
    {
        await UnityServices.InitializeAsync();
    }

    private async void createLobby()
    {
        try
        {
            string lobbyName = "lobbyName";
            int maxPlayers = 4;
            CreateLobbyOptions options = new CreateLobbyOptions();
            options.IsPrivate = true;
            lobby = await LobbyService.Instance.CreateLobbyAsync(lobbyName, maxPlayers, options);
            Debug.Log("Lobby created");
            Debug.Log("Created at date: " + lobby.Created);
            Debug.Log("Lobby name: " + lobby.Name);
            Debug.Log("Lobby ID: " + lobby.Id);
            Debug.Log("Lobby code: " + lobby.LobbyCode);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}