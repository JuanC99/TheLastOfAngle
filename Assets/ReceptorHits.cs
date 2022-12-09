using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


    public class ReceptorHits : MonoBehaviour
    {
    public UnityEvent myEvent;
    public void OnPointerEnter1()
    {
        this.GetComponent<Animator>().SetTrigger("Highlighted");
    }
    public void OnPointerExit1()
    {
        this.GetComponent<Animator>().SetTrigger("Normal");

    }
    public void OnPointerClick1()
    {
        this.GetComponent<Animator>().SetTrigger("Pressed");
    myEvent.Invoke();
    }
}
