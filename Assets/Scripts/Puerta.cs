using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : MonoBehaviour
{

    [SerializeField] string nivel = "Juego2";

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.CompareTag("Wisher")){
            StartCoroutine(GameManager.Instance.CargarXNivelAsync(nivel));
        }
    }
}
