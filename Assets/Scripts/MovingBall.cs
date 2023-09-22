using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class MovingBall : MonoBehaviour
{
    public float speed = 5.0f;
    Vector3 displacement = new Vector3(0.5f,0,0);
    public float radiusOfView = 5.0f;
    public GameObject text;
    public GameObject bulletPrefab;
    public float jumpForce = 75f;
    public Rigidbody2D rb;
    private MovingStar movingstar;
    public TMPro.TextMeshProUGUI gameOverText;
    public TMPro.TextMeshProUGUI YouWin;
    public Button restartButton;
    private Vector3 moveDirection = Vector3.zero;
    bool initial = true;
    // custom gravity direction
    private Vector3 customGravity = new Vector3(1f, -1f, 0f);
    public float fallSpeed = 7f;
    public LayerMask groundLayer;
    private bool isGrounded = false;

    public bool IsGrounded
    {
        get { return isGrounded; }
    }

    

    // Start is called before the first frame update
    void Start()
    {
        movingstar = FindObjectOfType<MovingStar>();
        Vector3 newPosition = transform.position;
        newPosition.x = movingstar.StarPosition.x;
        newPosition.y += 0.7f;
        transform.position = newPosition;
    }
     // Disable global gravity
    

    private void Update()
    {
         if (rb.velocity.y <= 0)
         {
             // Apply custom gravity when falling
             Vector2 newVelocity = customGravity.normalized * fallSpeed;
             rb.velocity = newVelocity;
         }
         else
         {   
             rb.gravityScale = 1f; // Restore the regular gravity scale

         }
      
        isGrounded = Physics2D.OverlapCircle(rb.position, 0.7f, groundLayer);
        

    }

    // Update is called once per frame
    void LateUpdate()
    {
        bool gameOverFlag = GameObject.FindGameObjectWithTag("GameOverFlag").GetComponent<GameOverFlagScript>().gameOverFlag;
        if(!gameOverFlag){

            Vector3 newPosition = transform.position;
            if (movingstar != null)
            {
                newPosition.x = movingstar.StarPosition.x;
                newPosition.y += 0.7f;
            }
            if (rb.position.x > 7)
            { 
                Win();
                GameObject.FindGameObjectWithTag("GameOverFlag").GetComponent<GameOverFlagScript>().gameOverFlag = true;
            }
            if (rb.position.y < -10)
            {
                GameOver();
                GameObject.FindGameObjectWithTag("GameOverFlag").GetComponent<GameOverFlagScript>().gameOverFlag = true;
            }
          
            float horizontalInput = Input.GetAxis("Horizontal");
            if (isGrounded)
            {
                if (horizontalInput < 0)
                {
                    // Left arrow key is pressed
                    moveDirection = Vector3.left;
                }
                else if (horizontalInput > 0)
                {
                    // Right arrow key is pressed
                    moveDirection = Vector3.right;
                }
                newPosition = transform.position + moveDirection * 0.5f * Time.deltaTime;
                // Update the transform's position
                transform.position = newPosition;
            }
             if (initial)
            {
                transform.position = newPosition;
            }

            initial = false;

            GameObject[] allGameObjects = GameObject.FindObjectsOfType<GameObject>();
            foreach(GameObject obj in allGameObjects){
                PlanetProperties customProperties = obj.GetComponent<PlanetProperties>();
                if (customProperties != null)
                {
                   
                    float distance = Vector3.Distance(rb.position, obj.transform.position);
                 
                    if(distance<=radiusOfView && obj.transform.childCount==2){
                        obj.transform.GetChild(0).gameObject.GetComponent<Renderer>().material.color = new Color(0,255,0);
                        if(Input.GetKeyDown(KeyCode.Tab)){
                        // if(Input.GetKeyDown("space")){
                            Object.Destroy(obj.transform.GetChild(1).gameObject);
                            obj.transform.GetChild(0).gameObject.GetComponent<Renderer>().material.color = new Color(255,255,255);
                            int curr_ammo = int.Parse(text.GetComponent<UnityEngine.UI.Text>().text.Substring(6));
                            int updated_ammo = curr_ammo+10;
                            text.GetComponent<UnityEngine.UI.Text>().text = "Ammo: "+updated_ammo.ToString();
                            break;
                        }

                    }
                 
                    else
                    {    
                            obj.transform.GetChild(0).gameObject.GetComponent<Renderer>().material.color = new Color(255,255,255);
                    }
                }
                //Debug.Log("isGrounded" + isGrounded);



            }
        }
        if (isGrounded && Input.GetKeyDown("space"))
        {
            Jump();
        }
    }
    private void Jump()
    {
        // Apply an upward force to the Rigidbody2D to make the ball jump.
        // Simulate the jump by changing the position in the Y-axis
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, 0);
    }
 
    void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    void Win()
    {
        YouWin.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }
 




}
