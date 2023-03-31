using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField]GameObject checkPointPrefab;
    [SerializeField]int delaySpawnCheckPoint = 5;
    [SerializeField]int radiusSpawnCheckPoint = 5;
    [SerializeField]GameObject[] powerUpPrefab;
    [SerializeField]int delaySpawnPowerUp = 5;
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
            if (GameManager.Instance.difficulty > 5)
            {
                
                yield return new WaitForSeconds(delaySpawnPowerUp / (GameManager.Instance.difficulty/5));
            }
            else{
                yield return new WaitForSeconds(delaySpawnPowerUp);
            }
            //Vector2 randomPosition = Random.insideUnitCircle * radiusSpawnCheckPoint;
            //Instantiate(checkPointPrefab, randomPosition, Quaternion.identity);    
            Instantiate(checkPointPrefab);        
        }
    }

    IEnumerator SpawnPowerUpRoutine(){
        while (true)
        {
            if (GameManager.Instance.difficulty > 5)
            {
                
                yield return new WaitForSeconds(delaySpawnPowerUp / (GameManager.Instance.difficulty/5));
            }
            else{
                yield return new WaitForSeconds(delaySpawnPowerUp);
            }
            //Vector2 randomPosition = Random.insideUnitCircle * radiusSpawnPowerUp;
            float random = Random.Range(0.0f, 1.0f);
            //int random = Random.Range(0, powerUpPrefab.Length);
            if (random < 0.1f && !GameManager.Instance.superDisparoCargadoGameManager)
            {
                Instantiate(powerUpPrefab[0]);
            }
            else
            {
                Instantiate(powerUpPrefab[1]);
            }
            //Instantiate(powerUpPrefab[random], randomPosition, Quaternion.identity);            
        }
    }
}

            

            