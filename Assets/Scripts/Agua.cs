using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agua : MonoBehaviour
{
    float velocidadOriginal;
    Wisher wisher;
    [SerializeField]float reduccionVelocidad = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        wisher = FindObjectOfType<Wisher>();
        velocidadOriginal = wisher.speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.CompareTag("Wisher")){
            wisher.speed *= reduccionVelocidad;
        }
    }

    private void OnTriggerExit2D(Collider2D collision){
        if (collision.CompareTag("Wisher")){
            wisher.speed = velocidadOriginal;
        }
    }
}
