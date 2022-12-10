using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class LauchManager : MonoBehaviour
{

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }


    void Update()
    {
        
    }
}
