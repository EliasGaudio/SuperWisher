using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int time = 30;
    public int difficulty = 1;
    public bool derrotaBool = false; 
    public int puntuacion;

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
        SceneManager.LoadScene("Juego");
    }
}
