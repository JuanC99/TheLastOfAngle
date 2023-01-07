using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;
public class personalHints : MonoBehaviour
{
    [SerializeField]private SteamVR_Action_Boolean action;
    private bool bActiveHints = false;
    private bool bAnterior = false;
    void Start()
    {
        bAnterior = !bActiveHints;
    }
    void Update()
    {
        if (bActiveHints != bAnterior)
        {
            if (bActiveHints)
            {
                activeHint(action);
            }
            else
            {
                disableHints();
            }
        }
        bAnterior = bActiveHints;
    }
    private void disableHints()
    {
        foreach (Hand hand in this.GetComponent<Player>().hands)
        {
            ControllerButtonHints.HideAllTextHints(hand);
        }
    }
    private void activeHint(ISteamVR_Action_In action)
    {
        disableHints();
        foreach (Hand hand in this.GetComponent<Player>().hands)
        {
            ControllerButtonHints.ShowTextHint(hand, action, action.GetShortName());
        }
    }
    public void activateHints(bool bActivate)
    {
        bActiveHints = bActivate;
    }
}