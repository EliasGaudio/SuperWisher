using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField]GameObject checkPointPrefab;
    [SerializeField]int delaySpawnCheckPoint = 10;
    [SerializeField]int radiusSpawnCheckPoint = 5;
    [SerializeField]GameObject[] powerUpPrefab;
    [SerializeField]int delaySpawnPowerUp = 10;
    [SerializeField]int radiusSpawnPowerUp = 5;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnCheckPointRoutine());
        StartCoroutine(SpawnPowerUpRoutine());
    }

    IEnumerator SpawnCheckPointRoutine(){
        while (true)
        {
            yield return new WaitForSeconds(delaySpawnCheckPoint);
            Vector2 randomPosition = Random.insideUnitCircle * radiusSpawnCheckPoint;
            Instantiate(checkPointPrefab, randomPosition, Quaternion.identity);            
        }
    }

    IEnumerator SpawnPowerUpRoutine(){
        while (true)
        {
            yield return new WaitForSeconds(delaySpawnPowerUp);
            Vector2 randomPosition = Random.insideUnitCircle * radiusSpawnPowerUp;
            int random = Random.Range(0, powerUpPrefab.Length);
            Instantiate(powerUpPrefab[random], randomPosition, Quaternion.identity);            
        }
    }
}
