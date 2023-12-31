using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    // Start is called before the first frame update
    private Camera mainCam;
    private Vector3 mousePos;
    public GameObject bulletPrefab;
    public Transform bulletTransform;
    public GameObject text;
    public bool canFire = true;
    private float timer;
    public float timeBetweenFiring = 0.3f;

    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        bool gameOverFlag = GameObject.FindGameObjectWithTag("GameOverFlag").GetComponent<GameOverFlagScript>().gameOverFlag;
        if(!gameOverFlag){
            mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
            Vector3 rotation = mousePos - transform.position;
            float rotZ = Mathf.Atan2(rotation.y,rotation.x)*Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0,0,rotZ);

            if(!canFire){
                timer += Time.deltaTime;
                if(timer>timeBetweenFiring){
                    canFire = true;
                    timer=0;
                }
            }
            if(Input.GetMouseButton(0) && canFire && int.Parse(text.GetComponent<UnityEngine.UI.Text>().text.Substring(6))>0){
                canFire = false;
                Instantiate(bulletPrefab, bulletTransform.position, Quaternion.identity);
                int curr_ammo = int.Parse(text.GetComponent<UnityEngine.UI.Text>().text.Substring(6));
                int updated_ammo = curr_ammo-1;
                text.GetComponent<UnityEngine.UI.Text>().text = "Ammo: "+updated_ammo.ToString();
            }
        }
    }
}
