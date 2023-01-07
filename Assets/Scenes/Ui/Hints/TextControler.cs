using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TextControler : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private float typingSpeed = 0.04f;
    [SerializeField] private List<string> listaIntroduccion;

    private Coroutine displayDialogueCoroutine;
    private int contadorLista = 0;
    private List<string> listaActual;
    private bool lecturaActiva;


    // Start is called before the first frame update
    void Start()
    {
        //LeerTexto(listaIntroduccion);
    }

    void Update()
    {
        if (lecturaActiva)
        {
            if (Input.GetKeyDown("space"))
            {
                if (displayDialogueCoroutine != null)
                {
                    StopCoroutine(displayDialogueCoroutine);
                }
                NextLine();
            }
        }
    }

    private IEnumerator DisplayLine(string line)
    {
        dialogueText.text = "";

        foreach(char c in line.ToCharArray())
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    private void LeerTexto(List<string> lista)
    {
        listaActual = lista;
        lecturaActiva = true;
        NextLine();
    }

    private void NextLine()
    {
        if (contadorLista >= listaActual.Count)
        {
            dialogueText.text = "";
            lecturaActiva = false;
        }
        else
        {
            displayDialogueCoroutine = StartCoroutine(DisplayLine(listaActual[contadorLista]));
            contadorLista++;
        }
        
    }

}
