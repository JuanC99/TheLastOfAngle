using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.Extras;
using Valve.VR;
using Valve.VR.InteractionSystem;


public class excavacion : MonoBehaviour
{
    Animator animator;
    public GameObject objetoExcavacion;
    public GameObject objetoDesaparecido;
    public GameObject particulas;
    public SteamVR_Action_Boolean cogeObjeto;
    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "pala")
        {
            Debug.Log("pala");
            objetoExcavacion.SetActive(true);
            animator.Play("objeto_saliendo");
            particulas.SetActive(false);
        }
        
    }

    private void Update()
    {
        
       /* if (cogeObjeto[this.GetComponent<Hand>().handType].stateDown)
        {
           
            if (objetoExcavacion.activeSelf)
            {
                objetoExcavacion.SetActive(false);
                animator.gameObject.SetActive(false);
                objetoDesaparecido.SetActive(true);
            }

            //Debug.Log("Apretado");
        }*/
    }
}
