using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.Extras;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class sonarEvent : MonoBehaviour
{
    public SteamVR_Action_Boolean activaSonar;

    bool haSidoApretado = false;
    private void Update()
    {
        if (activaSonar[this.GetComponent<Hand>().handType].stateDown)
        {
            haSidoApretado = true;
            Debug.Log("Apretado");
        }
        if (activaSonar[this.GetComponent<Hand>().handType].stateUp)
        {
            Debug.Log("Soltado");
            haSidoApretado = false;
        }
    }
}
