using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawn : MonoBehaviour
{
    public GameObject StarPrefab;
    private Vector3 initialPosition;
    public Vector3 StarPosition { get; private set; }
    private GameObject cuboidPrefab;
    private float timer = 0f;
    private GameObject currentCuboid;
    private Vector3 nextPosition;
    private Vector3 prevPosition;
    int alt = 1;
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = StarPrefab.transform.position;
        currentCuboid = StarPrefab.transform.gameObject;
        cuboidPrefab= StarPrefab.transform.gameObject;
        nextPosition = initialPosition;
        prevPosition = initialPosition;
        InvokeRepeating("SpawnObject", 0f, 2.5f);

    }
    private void Update()
    {
        StarPosition = transform.position;

    }
    void SpawnObject()
    {
        bool gameOverFlag = GameObject.FindGameObjectWithTag("GameOverFlag").GetComponent<GameOverFlagScript>().gameOverFlag;

        if (!gameOverFlag)
        {
            prevPosition = nextPosition;
            Vector3 spawnPosition = new Vector3(nextPosition.x, nextPosition.y, 0f);
            currentCuboid = Instantiate(cuboidPrefab, spawnPosition, Quaternion.identity);
           // Debug.Log(" Position" + cuboidPrefab.transform.localPosition.x + "next" + nextPosition.x);
            if (alt % 2 != 0)
            {
                nextPosition.y = initialPosition.y+1.3f;
            } else if (alt % 5 == 0)
            {
                nextPosition.y = initialPosition.y-1.3f;
            }
            else
            {
                nextPosition.y = initialPosition.y;
            }
            nextPosition.x = prevPosition.x + 9f;
            alt++;
        }

    }
}
