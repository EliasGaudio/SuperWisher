using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wisher : MonoBehaviour
{
    float h;
    float v;
    [SerializeField]float speed = 3;
    Vector3 moveDirection;
    [SerializeField]Transform mira;
    [SerializeField]Camera camara;
    Vector2 direccionMira;
    [SerializeField]Transform bala;
    bool cargaArma = true;
    [SerializeField]float velocidadDisparo = 1;
    [SerializeField]int vidaWisher = 10;
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
            Instantiate(bala, transform.position, rotacion);
            StartCoroutine(Recargar());
        }
        if (vidaWisher == 0){
            Destroy(gameObject);
        }
    }

    IEnumerator Recargar(){
        yield return new WaitForSeconds(1/velocidadDisparo);
        cargaArma = true;
    }

    public void RecibirDamageWisher(){
        vidaWisher--;
    }
}
