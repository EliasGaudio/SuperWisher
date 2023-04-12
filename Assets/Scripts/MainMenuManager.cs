using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] GameObject diamante;
    [SerializeField] GameObject menuPrincipal;
    [SerializeField] GameObject menuOpciones;
    [SerializeField] GameObject pantallaCarga;
    [SerializeField] GameObject[] luces;
    [SerializeField] string nivel = "Juego";
    // Start is called before the first frame update
    void Start()
    {
        luces = GameObject.FindGameObjectsWithTag("luz");
    }

    // Update is called once per frame
    void Update()
    {

        foreach ( GameObject luz in luces)
        {
            luz.transform.Rotate(new Vector3 (0, 0, 20) * Time.deltaTime);
        }
        diamante.transform.Rotate(new Vector3 (0, 100, 0) * Time.deltaTime);

    }

    public void IniciarJuego() {
        Invoke("LoadGame", 0.1f);
    }
    public void SalirDelJuego() {
        Invoke("CerrarJuego", 0.1f);
    }
    public void MenuOpcionesAbrir() {
        Invoke("AbrirMenuOpciones", 0.1f);
    }
    public void MenuOpcionesCerrar() {
        Invoke("CerrarMenuOpciones", 0.1f);
    }
    public void PantallaDeCarga() {
        Invoke("PonerPantallaDeCarga", 0.1f);
    }

    void LoadGame(){
        Invoke("PantallaDeCarga", 0.1f);
        
        StartCoroutine(LoadYourAsyncScene());

        GameManager.Instance.partidaIniciada = true;
        GameManager.Instance.ComenzarPartida();
    }



    void CerrarJuego(){
        Application.Quit();
    }
    void PonerPantallaDeCarga(){
        menuPrincipal.SetActive(false);
        pantallaCarga.SetActive(true);
    }
    void AbrirMenuOpciones(){
        menuPrincipal.SetActive(false);
        menuOpciones.SetActive(true);
    }
    void CerrarMenuOpciones(){
        menuPrincipal.SetActive(true);
        menuOpciones.SetActive(false);
    }



    IEnumerator LoadYourAsyncScene()
    {

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(nivel);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        
    }
}
