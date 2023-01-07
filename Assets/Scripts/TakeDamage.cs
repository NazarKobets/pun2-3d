using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class TakeDamage : MonoBehaviour
{
    [SerializeField] private Image healthBar;

    private float health;
    public float startHealth = 100;
    void Start()
    {
        health = startHealth;
        healthBar.fillAmount = health / startHealth;
    }

    [PunRPC]
    public void TakingDamage(float damage)
    {
        health -= damage;
        Debug.Log(health);
        healthBar.fillAmount = health / startHealth;
    }
}
