using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    public Text text;
    public int startingAmmo = 10;
    void Start()
    {
        text.text="Ammo: "+startingAmmo.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
