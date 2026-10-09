using Mirror;
using UnityEngine;

public class SharedCounter : NetworkBehaviour
{
    public static SharedCounter Instance { get; private set; }

    [SyncVar]  //fa sincronizzare il valore value dal server ai client
    public int value = 0;

    private void Awake()
    {
        Instance = this;
    }

    [Server]  //lo può fare solo il server
    public void Increment()
    {
        value++;
    }

    private void OnDestroy()
    {
        if (Instance == this)
            Instance = null;
    }
}
