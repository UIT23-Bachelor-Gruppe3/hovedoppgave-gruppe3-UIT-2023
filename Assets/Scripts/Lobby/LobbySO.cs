using System;
using System.Threading.Tasks;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using Unity.Networking.Transport.Relay;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.Lobbies;
using Unity.Services.Lobbies.Models;
using Unity.Services.Relay;
using Unity.Services.Relay.Models;
using UnityEngine;
using UnityEngine.SceneManagement;


[CreateAssetMenu]
public class LobbySO : ScriptableObject
{
    public Lobby lobby;
    [SerializeField] RelaySO relaySO;


    private async Task initAsyncIfNeeded()
    {
        // Initialize async and sign in if not allready completed
        if (!UnityServices.InitializeAsync().IsCompletedSuccessfully)
        {
            await UnityServices.InitializeAsync();
            Debug.Log("Initialize Unity Async");
        }
    }

    public async void CreateLobbyAsync(string lobbyName, string playerName)
    {
        Debug.Log("Starter CreateLobbyAsync");
        try

        {
            await initAsyncIfNeeded();
            if (!AuthenticationService.Instance.IsSignedIn) { await relaySO.SignIn(); }
            await relaySO.CreateRelay();

            // set options for lobby
            int maxPlayers = 4;
            CreateLobbyOptions options = new CreateLobbyOptions();
            options.IsPrivate = true;


            // Create lobby
            lobby = await LobbyService.Instance.CreateLobbyAsync(lobbyName, maxPlayers, options);

            // Lots of debugging
            Debug.Log("Lobby created");
            Debug.Log("Created at date: " + lobby.Created);
            Debug.Log("Lobby name: " + lobby.Name);
            Debug.Log("Lobby ID: " + lobby.Id);
            Debug.Log("Lobby code: " + lobby.LobbyCode);


            // Load next scene
            SceneManager.LoadScene("Lobby");

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async void JoinLobbyAsync(string lobbyCode)
    {
        Debug.Log("Starter JoinLobbyAsync");
        try
        {
            await initAsyncIfNeeded();
            await LobbyService.Instance.JoinLobbyByCodeAsync(lobbyCode);
            Debug.Log("Join lobby by code");

            // Load next scene
            SceneManager.LoadScene("Lobby");

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}
