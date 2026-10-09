using Mirror;
using UnityEngine;

public class PlayerCounter : NetworkBehaviour
{
    public void RequestIncrement()
    {
        if(!isLocalPlayer)
            return;

        CmdIncrement();
    }

    [Command]
    private void CmdIncrement()
    {
        if(SharedCounter.Instance != null)
        {
            SharedCounter.Instance.Increment();
        }
    }
}
