using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullSpawner : MonoBehaviour
{
    [SerializeField] GameObject prefabSkull;
    [SerializeField] GameObject prefabSkull2;
    GameObject spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = GameObject.FindGameObjectWithTag("SkullSpawner");
        StartCoroutine(SpawnerEnemigo());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnerEnemigo(){
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            Instantiate(prefabSkull, spawnPoint.transform);
            Instantiate(prefabSkull2, spawnPoint.transform);
        }
    }
}
