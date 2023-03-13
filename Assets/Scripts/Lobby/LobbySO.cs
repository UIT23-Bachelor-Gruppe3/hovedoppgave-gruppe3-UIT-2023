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

public struct RelayHostData
{
    public string JoinCode;
    public string IPv4Address;
    public ushort Port;
    public Guid AllocationID;
    public byte[] AllocationIDBytes;
    public byte[] ConnectionData;
    public byte[] Key;
}

[CreateAssetMenu]
public class LobbySO : ScriptableObject

{
    public Lobby lobby;
    public string lobbyCreatorID;

    // fra gamle RelayConnector
    private string joinCode;
    public Allocation allocation;


    private async Task initAsyncIfNeeded()
    {
        // Initialize async and sign in if not allready completed
        if (!UnityServices.InitializeAsync().IsCompletedSuccessfully) { await UnityServices.InitializeAsync(); }
    }



    public async void CreateLobbyAsync(string lobbyName, string playerName)
    {
        Debug.Log("Starter CreateLobbyAsync");
        try

        {
            await initAsyncIfNeeded();
            if (!AuthenticationService.Instance.IsSignedIn) { await SignIn(); }
            await CreateRelay();

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
    private async Task SignIn()
    {
        Debug.Log("Starter SignIn");
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
        Debug.Log("Starter JoinLobbyAsync");
        try
        {
            await initAsyncIfNeeded();
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


    public async Task CreateRelay()
    {
        Debug.Log("kjører CreateRelay");
        try
        {
            await initAsyncIfNeeded();
            allocation = await RelayService.Instance.CreateAllocationAsync(3); // Reserving space for 4 players
            joinCode = await RelayService.Instance.GetJoinCodeAsync(allocation.AllocationId);
            Debug.Log("; JoinCode: " + joinCode);

        }
        catch (RelayServiceException e)
        {
            Debug.Log(e);
        }
    }

    public void StartHost()
    {
        //relayConnector = FindObjectOfType<RelayConnector>();
        //allocation = relayConnector.allocation;
        try
        {
            if (allocation != null)
            {
                RelayServerData relayServerData = new RelayServerData(allocation, "dtls");
                NetworkManager.Singleton.GetComponent<UnityTransport>().SetRelayServerData(relayServerData);
                NetworkManager.Singleton.StartHost();
            }
            else
            {
                // denne fyrer at the moment...
                Debug.Log("allocation was null...");
            }
        }
        catch (Exception e) { Debug.Log(e); }
    }
}
