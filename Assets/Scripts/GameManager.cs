using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int time = 30;
    public int difficulty = 1;
    [SerializeField]int puntuacion;

    public int Puntuacion {
        get => puntuacion;
        set {
            puntuacion = value;
            if(puntuacion % 1000 == 0){
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
        while (time > 0)
        {
            yield return new WaitForSeconds(1);
            time--;
        }
    }
}
