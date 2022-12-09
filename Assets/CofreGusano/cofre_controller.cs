using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cofre_controller : MonoBehaviour
{
    
    Animator animator;
    public GameObject gusano;
    Animator anim_gusano;
    AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        
        animator = gameObject.GetComponentInChildren<Animator>();
        anim_gusano = gusano.GetComponentInChildren<Animator>();
        audio = gusano.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter1()
    {
        Debug.Log("Esta tocando el cofre");
        animator.Play("abrir_cofre");
    }
    public void OnPointerExit1()
    {
        Debug.Log("Dejo de tocar el cofre");
        animator.Play("cerrar_cofre");
    }
    public void OnPointerClick1()
    {
        Debug.Log("Click en el cofre");
        gusano.SetActive(true);
        anim_gusano.Play("animacion_gusano");
        if (!audio.isPlaying)
        {
            audio.Play();
        }
        
    }
}
