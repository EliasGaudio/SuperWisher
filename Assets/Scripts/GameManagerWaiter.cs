using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerWaiter : MonoBehaviour
{
    public void JugarDeNuevoWaiter(){
        GameManager.Instance.JugarDeNuevo();
    }

    public void SalirWaiter(){
        GameManager.Instance.Salir();
    }

    public void VolverAlMenuWaiter(){
        GameManager.Instance.VolverAlMenu();
    }
    
    public void SegundoNivelWaiter(){
        GameManager.Instance.SegundoNivel();
    }
}
