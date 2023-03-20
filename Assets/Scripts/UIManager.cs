using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField]TextMeshProUGUI textoVida;
    [SerializeField]TextMeshProUGUI textoPuntuacion;
    [SerializeField]TextMeshProUGUI textoTiempo;
    [SerializeField]GameObject pantallaDerrota;
    [SerializeField]TextMeshProUGUI textoPuntuacionFinal;
    [SerializeField]TextMeshProUGUI textoCadencia;
    [SerializeField]TextMeshProUGUI textoBalas;

    private void Awake(){
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void UpdateUIPuntuacion(int nuevaPuntuacion) {
        textoPuntuacion.text = nuevaPuntuacion.ToString();
    }

    public void UpdateUIVida(int nuevaVida) {
        textoVida.text = nuevaVida.ToString();
    }

    public void UpdateUITiempo(int nuevoTiempo) {
        textoTiempo.text = nuevoTiempo.ToString();
    }

    public void UpdateUICadencia(float nuevaCadencia) {
        textoCadencia.text = nuevaCadencia.ToString();
    }

    public void UpdateUIBalas(bool nuevasBalas) {
        if (nuevasBalas){
            textoBalas.text = "Si";
        }
        else
        {
            textoBalas.text = "No";
        }
        
    }

    public void MostrarDerrota() {
        Time.timeScale = 0;
        pantallaDerrota.SetActive(true);
        textoPuntuacionFinal.text = "" + GameManager.Instance.puntuacion;
    }
}
