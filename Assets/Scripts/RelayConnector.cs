using System.Collections;
using System.Collections.Generic;
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
    public static RelayConnector instance;
    public string joinCode;

    private async void Start()
    {
        if(instance != null && instance != this)
        {
            Destroy(this); //make sure only one singleton exist at any time
            Debug.Log("RelayConnector was destoyed, because another Singleton was created");
        }

        instance = this;

        await UnityServices.InitializeAsync();

        AuthenticationService.Instance.SignedIn += () =>
        {
            Debug.Log("Signed In; player ID: " + AuthenticationService.Instance.PlayerId);
        };
        await AuthenticationService.Instance.SignInAnonymouslyAsync();

        //CreateRelay(); //hardcoded for testing without an interface or console. run on host (serverside) 
        //JoinRelay(code); //run on client with the code that is provided by the host

    }

    [Command]
    public async void CreateRelay() //preferrably should be private
    {
        try
        {
            Allocation allocation = await RelayService.Instance.CreateAllocationAsync(3);

            joinCode = await RelayService.Instance.GetJoinCodeAsync(allocation.AllocationId);


            Debug.Log("; JoinCode: " + joinCode);

            RelayServerData relayServerData = new RelayServerData(allocation, "dtls");
            NetworkManager.Singleton.GetComponent<UnityTransport>().SetRelayServerData(relayServerData);


            NetworkManager.Singleton.StartHost();


        }
        catch (RelayServiceException e)
        {
            Debug.Log(e);
        }

    }

    [Command]
    public async void JoinRelay(string joinCode)
    {
        try
        {
            Debug.Log("Joining Realy with " + joinCode);
            JoinAllocation joinAllocation = await RelayService.Instance.JoinAllocationAsync(joinCode);

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
