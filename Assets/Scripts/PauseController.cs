using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    public static bool gameIsPaused;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameIsPaused = !gameIsPaused;
            PauseGame();
        }
    }
    void PauseGame ()
    {
        if(gameIsPaused)
        {
            UIManager.Instance.MostrarPausa();
            Time.timeScale = 0f;
        }
        else 
        {
            UIManager.Instance.OcultarPausa();
            Time.timeScale = 1;
        }
    }
}
