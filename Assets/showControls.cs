using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
public class showControls : MonoBehaviour
{
    public bool bShowController = false;
    private bool bShowAnterior = false;
    private void Start()
    {
        StartCoroutine(waitForInit(3.0f));
    }
    void Update()
    {
        if (bShowAnterior != bShowController)
        {
            foreach (Hand hand in this.GetComponent<Player>().hands)
            {
                if (bShowController)
                {
                    hand.ShowController();
                    hand.SetSkeletonRangeOfMotion(Valve.VR.EVRSkeletalMotionRange.WithController);
                }
                else
                {
                    hand.HideController();
                    hand.SetSkeletonRangeOfMotion(Valve.VR.EVRSkeletalMotionRange.WithoutController);
                }
            }
        }
        bShowAnterior = bShowController;
    }
    IEnumerator waitForInit(float secs)
    {
        yield return new WaitForSeconds(secs);
        bShowAnterior = !bShowController;
    }
}