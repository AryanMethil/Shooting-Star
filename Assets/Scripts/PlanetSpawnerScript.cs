using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PlanetSpawnerScript : MonoBehaviour
{
    public GameObject planetPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        Vector3 randomSpawnPosition1 = new Vector3(Random.Range(-15,-7), Random.Range(-5,6),0);
        Instantiate(planetPrefab, randomSpawnPosition1, Quaternion.identity);

        Vector3 randomSpawnPosition2 = new Vector3(Random.Range(-7,1), Random.Range(-5,6),0);
        Instantiate(planetPrefab, randomSpawnPosition2, Quaternion.identity);

        Vector3 randomSpawnPosition3 = new Vector3(Random.Range(1,9), Random.Range(-5,6),0);
        Instantiate(planetPrefab, randomSpawnPosition3, Quaternion.identity);

        Vector3 randomSpawnPosition4 = new Vector3(Random.Range(9,16), Random.Range(-5,6),0);
        Instantiate(planetPrefab, randomSpawnPosition4, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
