using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    Transform wisher;
    [SerializeField]int vida = 1;
    [SerializeField]float speed = 1;
    bool ataqueListo = true;
    [SerializeField]float velocidadAtaque = 1;
    // Start is called before the first frame update
    void Start()
    {
        wisher = FindObjectOfType<Wisher>().transform;
    }
        // Update is called once per frame
    void Update()
    {
        if (wisher == null){
            Destroy(gameObject);
            return;
        }
        Vector2 direccion = wisher.position - transform.position;
        transform.position += (Vector3)direccion * Time.deltaTime * speed;
        if (vida == 0){
            Destroy(gameObject);
        }
    }
    public void RecibirDamage(){
        vida--;
    }
    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.CompareTag("Wisher") && ataqueListo){
            ataqueListo = false;
            collision.GetComponent<Wisher>().RecibirDamageWisher();
            StartCoroutine(RecargarMelee());
        }
    }
    IEnumerator RecargarMelee(){
        yield return new WaitForSeconds(1/velocidadAtaque);
        ataqueListo = true;
    }
}