using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; 


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
    public bool partidaIniciada = false;


    public int Puntuacion {
        get => puntuacion;
        set {
            puntuacion = value;
            UIManager.Instance.UpdateUIPuntuacion(puntuacion);
            if(puntuacion % (2000/GlobalDifficulty) == 0){
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
        

        
    }

    public void ComenzarPartida(){
        StartCoroutine(CountdownRoutine());
    }


    IEnumerator CountdownRoutine(){



        yield return new WaitForSeconds(1); //Depresion absoluta, horror, nadie deberia ver nunca esta linea de codigo
        
        
        
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
        time = 30;
        difficulty = 1;
        derrotaBool = false; 
        puntuacion = 0;
        vidaWisherGameManager = 10;
        velocidadDisparoGameManager = 1;
        superDisparoCargadoGameManager = false;
        SceneManager.LoadScene("Juego");
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

    public void DropdownDificultadGlobal(){
        GameObject a = GameObject.FindGameObjectWithTag("DificultadGlobalDropdown");
        GlobalDifficulty = a.GetComponent<TMP_Dropdown>().value + 1;
    }


    public IEnumerator CargarXNivelAsync(string NombreNivel){

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(NombreNivel);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
