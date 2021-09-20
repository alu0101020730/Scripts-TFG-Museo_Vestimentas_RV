using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCanvasController : MonoBehaviour
{
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject[] textos;
    [SerializeField] int posicionActualTextos;
    // Start is called before the first frame update
    void Start()
    {
        posicionActualTextos = 0;
        textos[0].SetActive(true);
        //StartCoroutine(Swap(3.0f)); //Temporal
    }

    //Temporal
    IEnumerator Swap(float waitTime)
    {
        bool cond = true;
        int cont = 0;
        while (cond)
        {
            cont++;
            if (cont == 2)
                cond = false;
            Siguiente();
            yield return new WaitForSeconds(waitTime);
        }

    }

    public void Anterior()
    {
        textos[posicionActualTextos].SetActive(false);
        posicionActualTextos -= 1;
        textos[posicionActualTextos].SetActive(true);

    }

    public void Siguiente()
    {
        textos[posicionActualTextos].SetActive(false);
        posicionActualTextos += 1;
        textos[posicionActualTextos].SetActive(true);
    }

    public void Desactivar()
    {
        canvas.SetActive(false);
    }
}
