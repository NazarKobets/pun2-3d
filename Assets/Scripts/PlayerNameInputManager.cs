using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class PlayerNameInputManager : MonoBehaviour
{
    public void SetPlayerName(string playername)
    {
         if (string.IsNullOrEmpty(playername))
         {
             Debug.LogWarning("Player name is empty");
             return;
         }
        
        PhotonNetwork.NickName = playername;
    }
}
