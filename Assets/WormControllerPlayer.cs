using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormControllerPlayer : MonoBehaviour
{
    [SerializeField] private WormController wormController;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            wormController.ActivateWorm();
        }
    }
}
