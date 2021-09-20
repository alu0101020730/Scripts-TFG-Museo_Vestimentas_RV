using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelosEstaticosController : MonoBehaviour
{
    [SerializeField] GameObject canvasTutorial;
    [SerializeField] GameObject personajeGuiaMuseo;
    [SerializeField] GameObject[] parModelosEstaticos;
    int posActualParModelosEstaticos;
    // Start is called before the first frame update
    void Start()
    {
        posActualParModelosEstaticos = 0;

        //StartCoroutine(Swap(3.0f));
    }

    IEnumerator Swap(float waitTime)
    {
        bool cond = true;

        while (cond)
        {
            AnteriorPlaza();
            yield return new WaitForSeconds(waitTime);
        }

    }

    public void Empezar()
    {
        parModelosEstaticos[posActualParModelosEstaticos].SetActive(true);
    }

    public void SiguienteGuia()
    {
        if (posActualParModelosEstaticos == (parModelosEstaticos.Length - 1))
        {
            parModelosEstaticos[posActualParModelosEstaticos].SetActive(false);
            posActualParModelosEstaticos = 0;
        }
        else
        {
            parModelosEstaticos[posActualParModelosEstaticos].SetActive(false);
            posActualParModelosEstaticos++;
            parModelosEstaticos[posActualParModelosEstaticos].SetActive(true);
        }
    }

    public void SiguientePlaza()
    {
        if (posActualParModelosEstaticos == (parModelosEstaticos.Length - 1))
        {
            parModelosEstaticos[posActualParModelosEstaticos].SetActive(false);
            posActualParModelosEstaticos = 0;
            parModelosEstaticos[posActualParModelosEstaticos].SetActive(true);
        }
        else
        {
            parModelosEstaticos[posActualParModelosEstaticos].SetActive(false);
            posActualParModelosEstaticos++;
            parModelosEstaticos[posActualParModelosEstaticos].SetActive(true);
        }
    }

    public void AnteriorPlaza()
    {
        if (posActualParModelosEstaticos == 0)
        {
            parModelosEstaticos[posActualParModelosEstaticos].SetActive(false);
            posActualParModelosEstaticos = (parModelosEstaticos.Length - 1);
            parModelosEstaticos[posActualParModelosEstaticos].SetActive(true);
        }
        else
        {
            parModelosEstaticos[posActualParModelosEstaticos].SetActive(false);
            posActualParModelosEstaticos--;
            parModelosEstaticos[posActualParModelosEstaticos].SetActive(true);
        }
    }
}
