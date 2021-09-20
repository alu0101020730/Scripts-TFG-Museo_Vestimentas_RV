using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VertexAnimationTools_30;
public class PersonajeGuiaMuseoController : MonoBehaviour
{
    bool animar = false;
    float maxTime = 1f;
    float time = 0.0f;
    bool canvasState;
    string[] nombreClips;
    int indexClipActual;
    PointCachePlayer pointCachePlayer;
    [SerializeField] GameObject canvasContinuar;
    [SerializeField] GameObject canvasTerminar;

    private void Awake()
    {
        nombreClips = new string[] { "Empezar", "Par1_2", "Par2_3", "Par3_4", "Par4_5", "Par5_6", "Par6_7", "Par7_8", "Fin" };
        indexClipActual = 0;
        pointCachePlayer = GetComponent<PointCachePlayer>();
        canvasState = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (animar)
        {
            time += Time.deltaTime;
            pointCachePlayer.Clip0NormalizedTime = time / maxTime;
            if (time >= maxTime)
            {
                time = 0.0f;
            }
        }
    }

    public void Empezar()
    {
        gameObject.GetComponent<Animator>().Play(nombreClips[indexClipActual]);
        indexClipActual++;
        pointCachePlayer.Clip0Weight = 1;
        animar = true;
    }

    public void Continuar()
    {
        gameObject.GetComponent<Animator>().Play(nombreClips[indexClipActual]);
        indexClipActual++;
        if(indexClipActual == nombreClips.Length )
            indexClipActual = 0;
        ActivarAnimacion();
    }

    public void ActivarAnimacion()
    {
        pointCachePlayer.Clip0Weight = 1;
        animar = true;
        SwapCanvas();
    }

    public void PararAnimacion()
    {
        pointCachePlayer.Clip0Weight = 0;
        time = 0.0f;
        animar = false;
        SwapCanvas();
    }

    public void SwapCanvas()
    {
        canvasState = !canvasState;
        canvasContinuar.SetActive(canvasState);
    }

    public void TerminarVisitaAnimacion()
    {
        pointCachePlayer.Clip0Weight = 0;
        time = 0.0f;
        animar = false;
        canvasTerminar.SetActive(true);
    }

    public void TerminarGuia()
    {
        DescativarCanvasTerminar();
        gameObject.GetComponent<Animator>().Play(nombreClips[indexClipActual]);
        indexClipActual++;
        if (indexClipActual == nombreClips.Length)
            indexClipActual = 0;
        pointCachePlayer.Clip0Weight = 1;
        animar = true;
    }

    public void DescativarCanvasTerminar()
    {
        canvasTerminar.SetActive(false);
    }

    public void PararAnimacionFin()
    {
        pointCachePlayer.Clip0Weight = 0;
        time = 0.0f;
        animar = false;
    }
    
}
