using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] int tiempoExtra = 10;
    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.CompareTag("Wisher"))
        {
            GameManager.Instance.time += tiempoExtra;
            Destroy(gameObject, 0.1f);
        }
    }
}
