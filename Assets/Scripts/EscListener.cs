using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscListener : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("escape")){
Application.LoadLevel("game_menu");
}
    }
}
