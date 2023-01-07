using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using Random = UnityEngine.Random;

public class LaunchManager : MonoBehaviourPunCallbacks
{
    public GameObject EnterGamePanel;
    public GameObject ConnectionStatusPanel;
    public GameObject LobbyPanel;


    #region Unity Methods

    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    void Start()
    {
        EnterGamePanel.SetActive(true);
        ConnectionStatusPanel.SetActive(false);
        LobbyPanel.SetActive(false);
        // PhotonNetwork.ConnectUsingSettings();
        // Debug.Log("kekekek");
    }

    void Update()
    {

    }

    #endregion

    #region Public Methods

    public void ConnectToPhotonServer()
    {
        if (!PhotonNetwork.IsConnected)
        {
            PhotonNetwork.ConnectUsingSettings();
            EnterGamePanel.SetActive(false);
            ConnectionStatusPanel.SetActive(true);
        }
    }

    public void JoinRandomRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    #endregion

    #region Photon Callbacks

    public override void OnConnectedToMaster()
    {
        ConnectionStatusPanel.SetActive(false);
        LobbyPanel.SetActive(true);
        Debug.Log(PhotonNetwork.NickName + " connected to photon server");
    }

    public override void OnConnected()
    {
        Debug.Log("Connected to Internet");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        base.OnJoinRandomFailed(returnCode, message);
        Debug.Log(message);

        CreateAndJoinRoom();
    }

    public override void OnJoinedRoom()
    {
        Debug.Log(PhotonNetwork.NickName + " joined to " + PhotonNetwork.CurrentRoom.Name);
        PhotonNetwork.LoadLevel("Game Scene");
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

    #endregion

    #region Private Methods

    private void CreateAndJoinRoom()
    {
        string randomRoomName = "Room " + Random.Range(0, 10000);
        // RoomOptions roomOptions = new RoomOptions();
        // roomOptions.MaxPlayers = 20;
        // roomOptions.IsOpen = true;
        // roomOptions.IsVisible = true;

        RoomOptions roomOptions = new RoomOptions
        {
            MaxPlayers = 20,
            IsOpen = true,
            IsVisible = true,
        };

        PhotonNetwork.CreateRoom(randomRoomName, roomOptions);
        // PhotonNetwork.JoinOrCreateRoom(randomRoomName, roomOptions, TypedLobby.Default);
    }

    #endregion
}

