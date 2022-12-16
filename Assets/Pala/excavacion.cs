using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class excavacion : MonoBehaviour
{
    Animator animator;
    public GameObject objetoExcavacion;
    public GameObject objetoDesaparecido;
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
        }
        
    }

    private void Update()
    {
        // Debug.Log("hola");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (objetoExcavacion.activeSelf)
            {
                objetoExcavacion.SetActive(false);
                animator.gameObject.SetActive(false);
                objetoDesaparecido.SetActive(true);
            }
        }
    }
}
