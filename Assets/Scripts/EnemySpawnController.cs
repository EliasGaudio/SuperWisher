using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{

    [SerializeField] GameObject[] prefabEnemigo;
    [Range(0,10)][SerializeField] float velocidadSpawn = 1;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnerEnemigo());
        StartCoroutine(SpawnerEnemigoQueDispara());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawnerEnemigo(){
        while (true)
        {
            yield return new WaitForSeconds(1/(velocidadSpawn * GameManager.Instance.difficulty/2));
            float random = Random.Range(0.0f, 1.0f);
            if (random < (GameManager.Instance.difficulty - 2) * 0.05f)
            {
                Instantiate(prefabEnemigo[0]);
            }
            else
            {
                Instantiate(prefabEnemigo[1]);
            }

        }
    }
    IEnumerator SpawnerEnemigoQueDispara(){
        while (true)
        {
            yield return new WaitForSeconds(5/(velocidadSpawn * GameManager.Instance.difficulty/2));
            Instantiate(prefabEnemigo[2]);
        }
    }
}
