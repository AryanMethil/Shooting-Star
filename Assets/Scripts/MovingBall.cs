using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBall : MonoBehaviour
{
    public float speed = 5.0f;
    Vector3 displacement = new Vector3(0.5f,0,0);
    public float radiusOfView = 5.0f;
    public GameObject text;
    public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        bool gameOverFlag = GameObject.FindGameObjectWithTag("GameOverFlag").GetComponent<GameOverFlagScript>().gameOverFlag;
        if(!gameOverFlag){
            transform.localPosition+=(displacement*speed*Time.deltaTime);
        
            GameObject[] allGameObjects = GameObject.FindObjectsOfType<GameObject>();
            foreach(GameObject obj in allGameObjects){
                PlanetProperties customProperties = obj.GetComponent<PlanetProperties>();
                if (customProperties != null)
                {
                    float distance = Vector3.Distance(transform.localPosition, obj.transform.position);
                    if(distance<=radiusOfView && obj.transform.childCount==2){
                        obj.transform.GetChild(0).gameObject.GetComponent<Renderer>().material.color = new Color(0,255,0);
                        if(Input.GetKeyDown("space")){
                            Object.Destroy(obj.transform.GetChild(1).gameObject);
                            obj.transform.GetChild(0).gameObject.GetComponent<Renderer>().material.color = new Color(255,255,255);
                            int curr_ammo = int.Parse(text.GetComponent<UnityEngine.UI.Text>().text.Substring(6));
                            int updated_ammo = curr_ammo+10;
                            text.GetComponent<UnityEngine.UI.Text>().text = "Ammo: "+updated_ammo.ToString();
                            break;
                        }
                    }
                    else{
                        obj.transform.GetChild(0).gameObject.GetComponent<Renderer>().material.color = new Color(255,255,255);
                    }
                }
            
            }
        }
    }
}
