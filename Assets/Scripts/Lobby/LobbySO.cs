using System;
using System.Threading.Tasks;
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
    public string lobbyCreatorID;

    // fra gamle RelayConnector
    private string joinCode;
    public Allocation allocation;


    public async void CreateLobbyAsync(string lobbyName, string playerName)
    {
        try

        {
            // Initialize async and sign in if not allready completed
            if (!UnityServices.InitializeAsync().IsCompletedSuccessfully) { await UnityServices.InitializeAsync(); }
            if (!AuthenticationService.Instance.IsSignedIn) { await SignIn(); }

            // set options for lobby
            int maxPlayers = 4;
            CreateLobbyOptions options = new CreateLobbyOptions();
            options.IsPrivate = true;

            //lobbyCreatorID = options.Player.AllocationId;
            lobbyCreatorID = "ape";


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
    private async Task SignIn()
    {
        try
        {
            AuthenticationService.Instance.SignedIn += () =>
            {
                Debug.Log("Signed In; player ID: " + AuthenticationService.Instance.PlayerId);
            };
            await AuthenticationService.Instance.SignInAnonymouslyAsync();
            /*relayManager.isInitialized = true;*/
            Debug.Log("RelayConnector initialized.");
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }

    public async void JoinLobbyAsync(string lobbyCode)
    {
        try
        {
            await LobbyService.Instance.JoinLobbyByCodeAsync(lobbyCode);
            Debug.Log("Join lobby by code");

            // Load next scene
            SceneManager.LoadScene("Lobby");

        }
        catch (LobbyServiceException e)
        {
            Debug.Log(e);
        }
    }


    public async void CreateRelay()
    {
        Debug.Log("kjører CreateRelay");
        try
        {
            allocation = await RelayService.Instance.CreateAllocationAsync(3);
            joinCode = await RelayService.Instance.GetJoinCodeAsync(allocation.AllocationId);
            Debug.Log("; JoinCode: " + joinCode);
        }
        catch (RelayServiceException e)
        {
            Debug.Log(e);
        }
    }



}
