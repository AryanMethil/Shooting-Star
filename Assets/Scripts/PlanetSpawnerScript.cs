using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PlanetSpawnerScript : MonoBehaviour
{
    public GameObject planetPrefab;
    public float minPlanetSpawnDistance = 8.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        List<Vector3> spawnLocations = new List<Vector3>();
        while(spawnLocations.Count<4){

            int calculateNewRandomPositionFlag = 1;
            Vector3 randomSpawnPosition = new Vector3(0,0,0);

            while(calculateNewRandomPositionFlag==1){

                randomSpawnPosition = new Vector3(Random.Range(-15,16), Random.Range(-5,6),0);
                calculateNewRandomPositionFlag=0;

                if(spawnLocations.Count>1){

                    foreach(Vector3 spawnLocation in spawnLocations){

                        if(Vector3.Distance(spawnLocation, randomSpawnPosition)<minPlanetSpawnDistance){

                            calculateNewRandomPositionFlag=1;
                            break;

                        }
                    }
                }
            }
            Instantiate(planetPrefab, randomSpawnPosition, Quaternion.identity);
            spawnLocations.Add(randomSpawnPosition);
            foreach (Vector3 location in spawnLocations)
            {
                Debug.Log("Plant position"+location);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
