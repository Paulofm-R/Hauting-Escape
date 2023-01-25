using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButton : MonoBehaviour
{
    // Start is called before the first frame update
void Update()
{
    if (Input.GetKey(KeyCode.Escape))
    {
        QuitGame();
    }
}

public void QuitGame()
{
    Application.Quit();
}
}
