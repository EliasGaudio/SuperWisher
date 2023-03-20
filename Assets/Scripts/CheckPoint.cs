using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] int tiempoExtra = 10;
    void Start()
    {
        GameObject[] spawnPoint = GameObject.FindGameObjectsWithTag("ItemSpawnPoint");
        int randomSpawnPoint = Random.Range(0, spawnPoint.Length);
        transform.position = spawnPoint[randomSpawnPoint].transform.position;
        
        //Instantiate(checkPointPrefab, randomPosition, Quaternion.identity);    
    }
    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.CompareTag("Wisher"))
        {
            GameManager.Instance.time += tiempoExtra;
            Destroy(gameObject, 0.1f);
        }
    }
}
