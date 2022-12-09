using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleportBehaviour : MonoBehaviour
{
    public Transform player;
    public float heigth;
    public void OnPointerClick1() { 
        
        player.position = new Vector3(transform.position.x, heigth, transform.position.z);
    }

    public void OnPointerExit1()
    {
    }
    public void OnPointerEnter1()
    {
    }
}

