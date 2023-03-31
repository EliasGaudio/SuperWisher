using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int time = 30;
    public int difficulty = 1;
    public int GlobalDifficulty = 1;
    public bool derrotaBool = false; 
    public int puntuacion;
    public int vidaWisherGameManager = 10;
    public float velocidadDisparoGameManager = 1;
    public bool superDisparoCargadoGameManager = false;


    public int Puntuacion {
        get => puntuacion;
        set {
            puntuacion = value;
            UIManager.Instance.UpdateUIPuntuacion(puntuacion);
            if(puntuacion % 2000 == 0){
                difficulty++;
            }
        }
    }

    


    void Awake()
    {

        if(Instance == null){
            Instance = this;
        }
        DontDestroyOnLoad(this.gameObject);

    }
    private void Start(){
        StartCoroutine(CountdownRoutine());

        
    }


    IEnumerator CountdownRoutine(){
        UIManager.Instance.UpdateUITiempo(time);
        while (time > 0)
        {
            yield return new WaitForSeconds(1);
            time--;
            UIManager.Instance.UpdateUITiempo(time);
        }

        derrotaBool = true;
        UIManager.Instance.MostrarDerrota();
    }

    public void JugarDeNuevo(){
        Time.timeScale = 1;
        Invoke("CargarPrimerNivel", 0.1f);
        
    }

    public void Salir(){
        Time.timeScale = 1;
        Invoke("CerrarJuego", 0.1f);
    }

    public void VolverAlMenu(){
        Time.timeScale = 1;
        Invoke("IrAlMenuPrincipal", 0.1f);
    }
    public void SegundoNivel(){
        Time.timeScale = 1;
        Invoke("CargarSegundoNivel", 0.1f);
    }
    void CargarPrimerNivel(){
        SceneManager.LoadScene("Juego");
        Destroy(gameObject);
    }

    void ReiniciarEscena(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void IrAlMenuPrincipal(){
        
        SceneManager.LoadScene("PantallaPrincipal");
        Destroy(gameObject);
    }

    void CerrarJuego(){
        Application.Quit();
    }
    
    void CargarSegundoNivel(){
        SceneManager.LoadScene("Juego2");
    }

    public IEnumerator CargarXNivelAsync(string NombreNivel){

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(NombreNivel);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
