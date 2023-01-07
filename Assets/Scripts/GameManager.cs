using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class GameManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject playerPrefab;
    void Start()
    {
        if (PhotonNetwork.IsConnected && playerPrefab != null)
        {
            int randomPoint = Random.Range(-20, 20);
            PhotonNetwork.Instantiate(playerPrefab.name, new Vector3(randomPoint, 0, randomPoint),
                    Quaternion.identity);
        }
    }

    void Update()
    {
        
    }
    
    public override void OnJoinedRoom()
    {
        Debug.Log(PhotonNetwork.NickName + " joined to " + PhotonNetwork.CurrentRoom.Name);
    }
    
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log(newPlayer.NickName
                  + " joined to "
                  + PhotonNetwork.CurrentRoom.Name
                  + ". Players in that room "
                  + PhotonNetwork.CurrentRoom.PlayerCount
                  + "/"
                  + PhotonNetwork.CurrentRoom.MaxPlayers
        );
    }
}
