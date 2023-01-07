using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private Camera fpsCamera;

    public float fireRate = 0.1f;
    private float fireTimer;

    void Update()
    {
        if (fireTimer < fireRate)
        {
            fireTimer += Time.deltaTime;
        }

        if (Input.GetButton("Fire1") && fireTimer > fireRate)
        {
            fireTimer = 0;

            // Shooting
            Ray ray = fpsCamera.ViewportPointToRay(pos: new Vector3(x: 0.5f, y: 0.5f));

            if (Physics.Raycast(ray, out var hit, maxDistance:100))
            {
                Debug.Log(hit.collider.gameObject.name);
            }
        }
    }
}
