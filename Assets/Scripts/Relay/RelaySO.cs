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
public class RelaySO : ScriptableObject
{
    private string joinCode;
    public Allocation allocation;


    public async Task SignIn()
    {
        Debug.Log("Starter SignIn");
        try
        {
            AuthenticationService.Instance.SignedIn += () =>
            {
                Debug.Log("Signed In; player ID: " + AuthenticationService.Instance.PlayerId);
            };
            await AuthenticationService.Instance.SignInAnonymouslyAsync();
            //relayManager.isInitialized = true;
            Debug.Log("RelayConnector initialized.");
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }

    public async Task CreateRelay()
    {
        Debug.Log("kjører CreateRelay");
        try
        {
            //await initAsyncIfNeeded();
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
        try
        {
            RelayServerData relayServerData = new RelayServerData(allocation, "dtls");
            NetworkManager.Singleton.GetComponent<UnityTransport>().SetRelayServerData(relayServerData);
            NetworkManager.Singleton.StartHost();
        }
        catch (Exception e) { Debug.Log(e); }
    }

}
