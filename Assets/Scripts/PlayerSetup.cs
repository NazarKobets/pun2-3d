using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class PlayerSetup : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject FPSCamera;

    private void Start()
    {
        MovementController movementController = GetComponent<MovementController>();
        Camera playerCamera = FPSCamera.GetComponent<Camera>();

        bool isEnabled = photonView.IsMine;

        movementController.enabled = isEnabled;
        playerCamera.enabled = isEnabled;
    }

    void Update()
    {
        
    }
}
