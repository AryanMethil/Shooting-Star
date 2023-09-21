using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovingEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject goodGuy;
    public Vector3 offset;
    public float speed = 5.0f;
    public Vector3 displacement = new Vector3(0.5f,0,0);
    public float slowedDuration = 20.0f;
    public float slowedTimer = 0.0f;
    public bool isSlowed = false;
    public TMPro.TextMeshProUGUI gameOverText;
    public Button restartButton;
    

    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        bool gameOverFlag = GameObject.FindGameObjectWithTag("GameOverFlag").GetComponent<GameOverFlagScript>().gameOverFlag;
        if(!gameOverFlag){
            if(isSlowed==true){
                slowedTimer+=Time.deltaTime;
                if(slowedTimer>=slowedDuration){
                    isSlowed=false;
                    slowedTimer=0.0f;
                    Rigidbody2D rb = GetComponent<Rigidbody2D>();
                    rb.constraints = RigidbodyConstraints2D.None;
                }
            
            }
            else{
                Vector3 direction = (goodGuy.transform.position - transform.localPosition).normalized;
                transform.localPosition+=(direction*speed*Time.deltaTime);
            }
        }
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        
        if(col.gameObject.name=="Bullet(Clone)"|| col.gameObject.name == "Star" ||col.gameObject.name=="Star 1(Clone)"){
            isSlowed=true;
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
        }
        else{
            
                GameObject.FindGameObjectWithTag("GameOverFlag").GetComponent<GameOverFlagScript>().gameOverFlag = true;
                GameOver();
            
            
        }
    }

    void GameOver(){
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }
}
