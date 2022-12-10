using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class PlayerNameInputManager : MonoBehaviour
{
    public void SetPlayerName(string playername)
    {
        if (string.IsNullOrEmpty(playername) && playername is null)
        {
            Debug.LogWarning(message: "Name is empty");
            return;
        }

        PhotonNetwork.NickName = playername;
    }
}
