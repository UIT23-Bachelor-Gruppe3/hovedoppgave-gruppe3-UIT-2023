using System;
using System.Threading.Tasks;
using Unity.Services.Core;
using Unity.Services.Authentication;
using UnityEngine;
using Unity.Services.Relay;
using Unity.Services.Relay.Models;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using Unity.Networking.Transport.Relay;
using QFSW.QC;

public class RelayConnector : MonoBehaviour
{
    //Singleton pattern: https://www.youtube.com/watch?v=2pCkInvkwZ0&t=125s
    public string joinCode;
    public Allocation allocation;
    public static RelayConnector instance;

    private void Start()
    {
        if (instance != null && instance != this)
        {
            // Object is a duplicate and will delete it self
            gameObject.SetActive(false); // prevents anything from using this before destroy
            Destroy(this);
        }
        else
        {
            instance = this;
            initialize();
        }
    }


    private async void initialize()
    {
        await UnityServices.InitializeAsync();

        AuthenticationService.Instance.SignedIn += () =>
        {
            Debug.Log("Signed In; player ID: " + AuthenticationService.Instance.PlayerId);
        };
        await AuthenticationService.Instance.SignInAnonymouslyAsync();
    }

    [Command]
    public async Task CreateRelay() //preferably should be private
    {
        Debug.Log("kjører CreateRelay");
        try
        {
            await UnityServices.InitializeAsync();

            allocation = await RelayService.Instance.CreateAllocationAsync(3);

            joinCode = await RelayService.Instance.GetJoinCodeAsync(allocation.AllocationId);

            Debug.Log("; JoinCode: " + joinCode);
        }
        catch (RelayServiceException e)
        {
            Debug.Log(e);
        }
    }


    [Command]
    public async void JoinRelay(string joinCodeIn)
    {
        try
        {
            Debug.Log("Joining Realy with " + joinCodeIn);
            JoinAllocation joinAllocation = await RelayService.Instance.JoinAllocationAsync(joinCodeIn);

            RelayServerData relayServerData = new RelayServerData(joinAllocation, "dtls");
            NetworkManager.Singleton.GetComponent<UnityTransport>().SetRelayServerData(relayServerData);

            NetworkManager.Singleton.StartClient();
        }
        catch (RelayServiceException e)
        {
            Debug.Log(e);
        }
    }
}