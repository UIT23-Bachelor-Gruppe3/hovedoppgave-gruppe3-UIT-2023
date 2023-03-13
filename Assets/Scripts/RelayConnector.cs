using System.Threading.Tasks;
using UnityEngine;
using Unity.Services.Relay;
using Unity.Services.Relay.Models;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using Unity.Networking.Transport.Relay;
using QFSW.QC;

public class RelayConnector : MonoBehaviour
{

    private string joinCode;
    public Allocation allocation;
    [SerializeField] RelayManager relayManager;

    [Command]
    public async Task CreateRelay()
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