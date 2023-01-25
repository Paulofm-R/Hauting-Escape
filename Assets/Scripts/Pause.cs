using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public static bool gameIsPaused;

    public GameObject QuitPause;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ResumeGame();
        }
    }
    void PauseGame ()
    {
        if(gameIsPaused)
        {
            Time.timeScale = 0f;
            QuitPause.gameObject.SetActive(true);
        }
        else 
        {
            Time.timeScale = 1;
            QuitPause.gameObject.SetActive(false);
        }
    }
    
    public void ResumeGame()
{
    gameIsPaused = !gameIsPaused;
    PauseGame();
}
}