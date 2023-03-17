using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    [SerializeField] float speed = 5;
    [SerializeField] int vida = 3;
    public bool superDisparoCargadoBala;

        // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5);
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * Time.deltaTime * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.CompareTag("Enemigo")){
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
    }
}
