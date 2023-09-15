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
        List<Vector3> spawnLocations = new List<Vector3>();
        while(spawnLocations.Count<4){

            int calculateNewRandomPositionFlag = 1;
            Vector3 randomSpawnPosition = new Vector3(0,0,0);

            while(calculateNewRandomPositionFlag==1){

                randomSpawnPosition = new Vector3(Random.Range(-15,16), Random.Range(-5,6),0);
                calculateNewRandomPositionFlag=0;

                if(spawnLocations.Count>1){

                    foreach(Vector3 spawnLocation in spawnLocations){

                        if(Vector3.Distance(spawnLocation, randomSpawnPosition)<2){

                            calculateNewRandomPositionFlag=1;
                            break;

                        }
                    }
                }
            }
            Instantiate(planetPrefab, randomSpawnPosition, Quaternion.identity);
            spawnLocations.Add(randomSpawnPosition);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
