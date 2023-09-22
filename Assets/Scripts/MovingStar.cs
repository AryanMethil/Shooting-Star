using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingStar : MonoBehaviour
{
    public float speed = 1.2f;
    Vector3 displacement = new Vector3(0.5f, 0, 0);
    public float moveDistance = 4.5f;
    private Vector3 initialPosition;
    public Vector3 StarPosition { get; private set; }
    public GameObject cuboidPrefab;
    private float direction = 1.0f;
    public float spawnInterval = 3f;
    int d = 1;
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;   
    }
    private void Update()
    {
        StarPosition = transform.position;
    }
    // Update is called once per frame
    void LateUpdate()
    {
        bool gameOverFlag = GameObject.FindGameObjectWithTag("GameOverFlag").GetComponent<GameOverFlagScript>().gameOverFlag;
        if (!gameOverFlag)
        {
            transform.Translate(Vector3.right * 1.5f * direction * Time.deltaTime);
            // Check if the cuboid has traveled the desired distance
            float traveledDistance = Vector3.Distance(initialPosition, transform.localPosition);
            if (traveledDistance >= moveDistance*d)
            {
                transform.gameObject.SetActive(false);
              //  Debug.Log("Spawn called " + moveDistance+ "traveled distance"+traveledDistance);
                d++;
            }

        }
    }

}
