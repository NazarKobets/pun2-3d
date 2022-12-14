using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using TMPro;
using UnityEngine;

public class PlayerSetup : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject FPSCamera;
    [SerializeField] private TMP_Text playerNameText;

    private void Start()
    {
        MovementController movementController = GetComponent<MovementController>();
        Camera playerCamera = FPSCamera.GetComponent<Camera>();

        bool isEnabled = photonView.IsMine;

        movementController.enabled = isEnabled;
        playerCamera.enabled = isEnabled;

        SetPlayerUI();
    }

    void SetPlayerUI()
    {
        if (playerNameText != null)
        {
            playerNameText.text = photonView.Owner.NickName;
        }
    }

    void Update()
    {
        
    }
}
