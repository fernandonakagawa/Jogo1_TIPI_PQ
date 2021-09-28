using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlacaInstrucoes : MonoBehaviour
{
    public GameObject avisoCanvas;
    public GameObject textoCanvas;
    private bool entendido;
    private int qtdNEntendi;
    void Start()
    {
        avisoCanvas.SetActive(false);
        entendido = false;
        qtdNEntendi = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("dino") && !entendido)
        {
            avisoCanvas.SetActive(true);
        }
    }

    public void ClicouEntendi()
    {
        entendido = true;
        avisoCanvas.SetActive(false);
    }

    public void ClicouNaoEntendi()
    {
        string texto = "";
        switch (qtdNEntendi)
        {
            case 0:
                texto = "Que pena... Não posso fazer nada por você!";
                break;
            case 1:
                texto = "Mas tu é lerdão hem!";
                break;
            case 2:
                texto = "Desisto de você...";
                break;
            default:
                avisoCanvas.SetActive(false);
                break;
        }
        qtdNEntendi++;
        textoCanvas.GetComponent<Text>().text = texto;
            
    }
}
