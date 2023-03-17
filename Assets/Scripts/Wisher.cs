using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wisher : MonoBehaviour
{
    float h;
    float v;
    public float speed = 3;
    Vector3 moveDirection;
    [SerializeField]Transform mira;
    [SerializeField]Camera camara;
    Vector2 direccionMira;
    [SerializeField]Transform bala;
    bool cargaArma = true;
    [SerializeField]float velocidadDisparo = 1;
    [SerializeField]float tiempoInvulnerabilidad = 3;
    [SerializeField]int vidaWisher = 10;
    bool superDisparoCargado = false;
    [SerializeField]bool invulnerable = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Movimiento
        h = Input.GetAxis("Horizontal");    
        v = Input.GetAxis("Vertical");
        moveDirection.x = h;
        moveDirection.y = v;
        transform.position += moveDirection * speed * Time.deltaTime;

        
    
        //Mira
        direccionMira = camara.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        mira.position = (Vector3)direccionMira.normalized + transform.position;

        //Bala
        if (Input.GetMouseButton(0) && cargaArma){
            cargaArma = false;
            float angle = Mathf.Atan2(direccionMira.y, direccionMira.x) * Mathf.Rad2Deg;
            Quaternion rotacion = Quaternion.AngleAxis(angle, Vector3.forward);
            Transform clonBala = Instantiate(bala, transform.position, rotacion);
            if (superDisparoCargado)
            {
                clonBala.GetComponent<Bala>().superDisparoCargadoBala = true;
            }
            StartCoroutine(Recargar());
        }
        
    }

    IEnumerator Recargar(){
        yield return new WaitForSeconds(1/velocidadDisparo);
        cargaArma = true;
    }

    IEnumerator Invulnerabilidad(){
        yield return new WaitForSeconds(tiempoInvulnerabilidad);
        invulnerable = false;
    }

    public void RecibirDamageWisher(){
        if (!invulnerable)
        {
            vidaWisher--;
            invulnerable = true;
            StartCoroutine(Invulnerabilidad());    
        }
        
        if (vidaWisher == 0){
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.CompareTag("PowerUp")){
            switch (collision.GetComponent<PowerUp>().powerUpType)
            {
                case PowerUp.PowerUpType.SuperCadenciaDeFuego:
                    velocidadDisparo++;
                    break;
                case PowerUp.PowerUpType.SuperPoderDeDisparo:
                    superDisparoCargado = true;
                    break;
            }
            Destroy(collision.gameObject, 0.1f);
        }
    }
}
