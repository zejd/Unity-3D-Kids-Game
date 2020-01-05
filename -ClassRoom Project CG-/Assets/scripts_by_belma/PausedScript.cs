using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausedScript : MonoBehaviour
{
    public Transform Canvas;
    public Transform Player;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            Pause();
        }
    }


    public void Pause()
    {
        if (Canvas.gameObject.activeInHierarchy == false)
        {
            Application.Quit();
        }
        else
        {
            Canvas.gameObject.SetActive(false);
            Time.timeScale = 1;
            Application.Quit();

        }
    }

    public void Restart()
    {
        Application.LoadLevel("ClassRoom");
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }

    public void MainMenu()
    {
        Application.LoadLevel(0);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
