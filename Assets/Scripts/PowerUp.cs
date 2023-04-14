using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public PowerUpType powerUpType;


    // Start is called before the first frame update
    void Start()
    {
        GameObject[] spawnPoint = GameObject.FindGameObjectsWithTag("ItemSpawnPoint");
        int randomSpawnPoint = Random.Range(0, spawnPoint.Length);
        if (powerUpType != PowerUp.PowerUpType.SuperCantidadDeBalas)
        {
            transform.position = spawnPoint[randomSpawnPoint].transform.position;
        }
        
    }
    public enum PowerUpType
    {
        SuperCadenciaDeFuego,
        SuperPoderDeDisparo,
        SuperCantidadDeBalas
    }

    
}
