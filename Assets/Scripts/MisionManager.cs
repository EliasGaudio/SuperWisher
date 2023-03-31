using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisionManager : MonoBehaviour
{
    public static MisionManager Instance;

    public List<Mision> misiones;

    private void Awake(){
        if (Instance == null)
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Mision mision1 = new Mision();
        mision1.descripcion = "Conseguir 10000 puntos"; 
        MisionManager.Instance.SumarMision(mision1);
        StartCoroutine(DisplayMision());

    }


    IEnumerator DisplayMision(){
        foreach (Mision mision in misiones)
        {
            yield return null;
            UIManager.Instance.MostrarMision(mision);
           
        }
        
    }

    public void SumarMision(Mision mision){
        misiones.Add(mision);
    }

}
