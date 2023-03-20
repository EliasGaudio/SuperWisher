using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] spawnPoint = GameObject.FindGameObjectsWithTag("ItemSpawnPoint");
        int randomSpawnPoint = Random.Range(0, spawnPoint.Length);

        transform.position = spawnPoint[randomSpawnPoint].transform.position;
    }
    public enum PowerUpType
    {
        SuperCadenciaDeFuego,
        SuperPoderDeDisparo
    }

    public PowerUpType powerUpType;
}
