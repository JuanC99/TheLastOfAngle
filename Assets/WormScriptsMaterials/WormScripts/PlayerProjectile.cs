using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    public float damage = 20f;
    [SerializeField] WormController wormController;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            wormController.ActivateWorm();
        }
    }
}
