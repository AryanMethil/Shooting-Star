using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverFlagScript : MonoBehaviour
{
    // Start is called before the first frame update
    public bool gameOverFlag;
    void Start()
    {
        gameOverFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
