using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class LauchManager : MonoBehaviourPunCallbacks
{
    public GameObject EnterGamePanel;
    public GameObject ConnectionStatusPanel;
    public GameObject LobbyPanel;


    #region Unity Methods
    void Start()
    {
        EnterGamePanel.SetActive(true);
        ConnectionStatusPanel.SetActive(false);
        LobbyPanel.SetActive(false);
        //PhotonNetwork.ConnectUsingSettings();
    }


    void Update()
    {

    }
    #endregion


    #region Photon Callbacks
    public void ConnectToPhotonServer()
    {
        if (!PhotonNetwork.IsConnected)
        {
            PhotonNetwork.ConnectUsingSettings();
            EnterGamePanel.SetActive(false);
            ConnectionStatusPanel.SetActive(true);
        }
    }
    #endregion


    #region Public Methods
    public override void OnConnectedToMaster()
    {
        Debug.Log(message: PhotonNetwork.NickName + " Connected to server");
        ConnectionStatusPanel.SetActive(false);
        LobbyPanel.SetActive(true);
    }

    public override void OnConnected()
    {
        Debug.Log(message: "Connected to internet");
    }
    #endregion


}
