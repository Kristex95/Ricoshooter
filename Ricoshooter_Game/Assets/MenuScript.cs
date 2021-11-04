using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;
using MLAPI.Transports.UNET;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public InputField IP_input;

    private void ApprovalCheck(byte[] connectionData, ulong clientID, NetworkManager.ConnectionApprovedDelegate callback)
    {
        bool approve = System.Text.Encoding.ASCII.GetString(connectionData) == "Pasword1234";
        callback(true, null, approve, new Vector3(1, 1, 1), Quaternion.identity);
    }

    public void Host()
    {
        NetworkManager.Singleton.StartHost();
    }

    public void Join()
    {
        if(IP_input.text.Length <= 0)
        {
            NetworkManager.Singleton.GetComponent<UNetTransport>().ConnectAddress = "127.0.0.1";
        }
        else
        {
            NetworkManager.Singleton.GetComponent<UNetTransport>().ConnectAddress = IP_input.text;
        }
        NetworkManager.Singleton.StartClient();
    }
}
