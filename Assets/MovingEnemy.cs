using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
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

    void OnCollisionEnter2D(Collision2D col)
    {
        
        if(col.gameObject.name=="Bullet(Clone)"){
            isSlowed=true;
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
        }
    }
}
