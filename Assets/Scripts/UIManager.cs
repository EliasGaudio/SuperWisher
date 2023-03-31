using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] TextMeshProUGUI textoVida;
    [SerializeField] TextMeshProUGUI textoPuntuacion;
    [SerializeField] TextMeshProUGUI textoTiempo;
    [SerializeField] GameObject pantallaDerrota;
    [SerializeField] GameObject pantallaPausa;
    [SerializeField] TextMeshProUGUI textoPuntuacionFinal;
    [SerializeField] TextMeshProUGUI textoCadencia;
    [SerializeField] TextMeshProUGUI textoBalas;
    [SerializeField] GameObject seccionMisiones;
    

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

    public void MostrarMision(Mision mision) {
        
        //TextMeshProUGUI textoMision = new TextMeshProUGUI(); 
        GameObject textoMision = seccionMisiones;
        textoMision.AddComponent<TextMeshProUGUI>();
        textoMision.gameObject.tag = "Mision";
        textoMision.gameObject.transform.parent = seccionMisiones.transform;
        textoMision.gameObject.transform.parent = seccionMisiones.transform;
        //textoMision.gameObject.GetComponent<RectTransform>() = seccionMisiones.GetComponent<RectTransform>();
        textoMision.gameObject.GetComponent<TextMeshProUGUI>().text = mision.descripcion;
        textoMision.gameObject.GetComponent<TextMeshProUGUI>().font = textoVida.GetComponent<TextMeshProUGUI>().font;
        textoMision.gameObject.GetComponent<TextMeshProUGUI>().fontSize = 20;
        textoMision.gameObject.transform.position = seccionMisiones.transform.position;
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

    public void MostrarPausa() {
        pantallaPausa.SetActive(true);
    }
    public void OcultarPausa() {
        pantallaPausa.SetActive(false);
    }
}
