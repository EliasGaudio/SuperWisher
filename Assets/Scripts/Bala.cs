using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    [SerializeField] float speed = 5;
    [SerializeField] int vida = 3;
    public bool superDisparoCargadoBala;
    [SerializeField]AudioSource audioSourceBala;

        // Start is called before the first frame update
    void Start()
    {
        audioSourceBala = GetComponent<AudioSource>();
        audioSourceBala.Play();
        Destroy(gameObject, 5);
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * Time.deltaTime * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.CompareTag("Enemigo") && !gameObject.CompareTag("BalaMala")){
            collision.GetComponent<Enemigo>().RecibirDamage();
            if (!superDisparoCargadoBala)
            {
                Destroy(gameObject);
            }
            vida--;
            if (vida == 0)
            {
                Destroy(gameObject);
            }
        }

        if (collision.CompareTag("Wisher") && gameObject.CompareTag("BalaMala"))
        {
            collision.GetComponent<Wisher>().RecibirDamageWisher();
        }

    }
}
