using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuiaPrincipalController : MonoBehaviour
{
    [SerializeField] GameObject canvasFinal;
    [SerializeField] GameObject canvasFlechasModelosPlaza;
    [SerializeField] GameObject modelosEstaticosGuiaGameObject;
    [SerializeField] GameObject modelosEstaticosPlazaGameObject;

    PersonajeGuiaMuseoController personajeGuiaMuseoController;
    ModelosEstaticosController modelosEstaticosGuiaController;
    ModelosEstaticosController modelosEstaticosPlazaController;

    // Start is called before the first frame update
    void Start()
    {
        modelosEstaticosGuiaController = modelosEstaticosGuiaGameObject.GetComponent<ModelosEstaticosController>();
        modelosEstaticosPlazaController =  modelosEstaticosPlazaGameObject.GetComponent<ModelosEstaticosController>();
        personajeGuiaMuseoController = GetComponent<PersonajeGuiaMuseoController>();
    }

    public void Empezar()
    {
        GetComponent<TutorialCanvasController>().Desactivar();
        modelosEstaticosGuiaController.Empezar();
        personajeGuiaMuseoController.Empezar();
    }

    public void Continuar()
    {
        modelosEstaticosGuiaController.SiguienteGuia();
        personajeGuiaMuseoController.Continuar();
    }

    public void TerminarPlaza()
    {
        modelosEstaticosPlazaGameObject.SetActive(false);
        canvasFlechasModelosPlaza.SetActive(false);
        modelosEstaticosGuiaGameObject.SetActive(true);
        canvasFinal.SetActive(false);
    }

    public void TerminarGuia()
    {
        personajeGuiaMuseoController.TerminarGuia();
        modelosEstaticosGuiaController.SiguienteGuia();
        modelosEstaticosGuiaGameObject.SetActive(false);
        modelosEstaticosPlazaGameObject.SetActive(true);
        canvasFlechasModelosPlaza.SetActive(true);
        canvasFinal.SetActive(true);
    }

    public void Repetir()
    {
        TerminarPlaza();
        Empezar();
    }
}
    