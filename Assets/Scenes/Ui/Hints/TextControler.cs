using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Valve.VR.Extras;
using Valve.VR;
using Valve.VR.InteractionSystem;
using UnityEngine.SceneManagement;

public class TextControler : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private float typingSpeed = 0.04f;
    [SerializeField] private SteamVR_Action_Boolean botonSiguienteTexto;
    [SerializeField] private GameObject rightHand;

    
    [SerializeField] private List<string> listaIntroduccion;

    private Coroutine displayDialogueCoroutine;
    private int contadorLista = 0;
    private List<string> listaActual;
    private bool lecturaActiva;

    public static bool activarTextoInicio;


    // Start is called before the first frame update
    void Start()
    {
        activarTextoInicio = false;


    }

    public void setActivarTextoInicio(bool b)
    {
        activarTextoInicio = b;
    }
    void Update()
    {
        if (lecturaActiva)
        {
            if (botonSiguienteTexto[rightHand.GetComponent<Hand>().handType].stateDown)
            {
                if (displayDialogueCoroutine != null)
                {
                    StopCoroutine(displayDialogueCoroutine);
                }
                NextLine();
            }
        }

        if (activarTextoInicio)
        {
            LeerTexto(listaIntroduccion);
            activarTextoInicio = false;
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
