using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cofre : MonoBehaviour
{
    [SerializeField]AudioClip abrirCofreSonido;
    [SerializeField]AudioSource audioSourceCofre;
    [SerializeField]GameObject mejora;
    public bool abierto = false;
    // Start is called before the first frame update
    public void abrirCofre(Transform posicionJugador){
        audioSourceCofre.clip = abrirCofreSonido;
        audioSourceCofre.Play();
        GameObject a = Instantiate(mejora, transform.position, Quaternion.identity);
        a.transform.position = posicionJugador.position;
        abierto = true;
    
    }



}
