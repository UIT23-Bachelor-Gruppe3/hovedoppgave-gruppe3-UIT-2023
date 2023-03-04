using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using TMPro;
using Unity.Collections;

public class PlayerSettings : NetworkBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private TextMeshProUGUI playerName;
    private readonly NetworkVariable<FixedString128Bytes> networkPlayerName = new("Player: 0", NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Server );

    public List<Color> colors = new();

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public override void OnNetworkSpawn()
    {
        networkPlayerName.Value = "Player: " + (OwnerClientId + 1);
        playerName.text = networkPlayerName.Value.ToString();
        spriteRenderer.color = colors[(int)OwnerClientId];
    }

}
