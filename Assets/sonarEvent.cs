using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.Extras;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class sonarEvent : MonoBehaviour
{
    public SteamVR_Action_Boolean activaSonar;
    public GameObject anillo;
    Animator animator_anillo;

    bool haSidoApretado = false;
    private void Start()
    {
        animator_anillo = anillo.GetComponent<Animator>();
    }
    private void Update()
    {
        if (activaSonar[this.GetComponent<Hand>().handType].stateDown)
        {
            haSidoApretado = true;
            animator_anillo.Play("abrirSonar");
            //Debug.Log("Apretado");
        }
        if (activaSonar[this.GetComponent<Hand>().handType].stateUp && haSidoApretado)
        {
            //Debug.Log("Soltado");
            haSidoApretado = false;
            animator_anillo.Play("cerrarSonar");
        }
    }
}
