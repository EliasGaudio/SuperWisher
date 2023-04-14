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
    [SerializeField]int recompensa = 100;
    [SerializeField] Animator anim2;
    [SerializeField]bool dispara = false;
    float angle;
    float angle2;
    [SerializeField] float rateBlinkeo = 0.001f;
    [SerializeField]int orientacion = 0;
    [SerializeField]AudioClip impacto;
    [SerializeField]AudioSource audioSourceEnemigo;
    [SerializeField] GameObject enemigoBala;
    // Start is called before the first frame update
    void Start()
    {
        audioSourceEnemigo = GetComponent<AudioSource>();
        wisher = FindObjectOfType<Wisher>().transform;
        GameObject[] spawnPoint = GameObject.FindGameObjectsWithTag("SpawnPoint");
        int randomSpawnPoint = Random.Range(0, spawnPoint.Length);
        transform.position = spawnPoint[randomSpawnPoint].transform.position;
        if (GameManager.Instance.GlobalDifficulty == 5){
            dispara = true;
        }
        if (dispara) {
            StartCoroutine(Disparar());
        }
        
    }
        // Update is called once per frame
    void Update()
    {
        if (wisher == null){
            Destroy(gameObject);
            return;
        }
        
        Vector2 direccion = wisher.position - transform.position;
        //transform.position += (Vector3)direccion * Time.deltaTime * speed;
        transform.position = Vector3.MoveTowards(transform.position, wisher.position, speed * Time.deltaTime);
        Vector2 directionUnit = (Vector3)direccion / direccion.magnitude;

        angle = Mathf.Atan2(directionUnit.y, directionUnit.x) * Mathf.Rad2Deg;
        if (angle > 45 && angle < 135)
        {
            orientacion = 1;
        }
        else if (angle > -45 && angle < 45)
        {
            orientacion = 3;
        }
        else if (angle > -135 && angle < -45)
        {
            orientacion = 0;
        }
        else
        {
            orientacion = 2;
        }
        
        
        anim2.SetInteger("Angulo", orientacion);
        anim2.SetFloat("Speed", 1); //Mejorable
        
    }


    public void RecibirDamage(){
        vida--;
        audioSourceEnemigo.clip = impacto;
        audioSourceEnemigo.Play();
        StartCoroutine(BlinkearEnemigo());
        if (vida == 0){
            GameManager.Instance.Puntuacion += recompensa;
            Destroy(gameObject, 0.1f);
        }
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

    IEnumerator BlinkearEnemigo(){
        int t = 10;
        while (t > 0)
        {
            gameObject.GetComponentInChildren<SpriteRenderer>().enabled = false;
            yield return new WaitForSeconds(t * rateBlinkeo);
            gameObject.GetComponentInChildren<SpriteRenderer>().enabled = true;
            yield return new WaitForSeconds(t * rateBlinkeo);
            t--;
        }
    }
    
    IEnumerator Disparar(){
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(2/GameManager.Instance.GlobalDifficulty, 10/GameManager.Instance.GlobalDifficulty));

            Vector2 direccion = wisher.position - transform.position;
            //transform.position += (Vector3)direccion * Time.deltaTime * speed;
            transform.position = Vector3.MoveTowards(transform.position, wisher.position, speed * Time.deltaTime);
            Vector2 directionUnit = (Vector3)direccion / direccion.magnitude;
            angle2 = Mathf.Atan2(directionUnit.y, directionUnit.x) * Mathf.Rad2Deg;

            //float angle = Mathf.Atan2(wisher.position.y, wisher.position.x) * Mathf.Rad2Deg;
            //Quaternion rotacion = Quaternion.AngleAxis(angle, Vector3.forward);
            Quaternion rotacion = Quaternion.AngleAxis(angle2, Vector3.forward);
            Instantiate(enemigoBala, transform.position, rotacion);
        
        }
    }
}
