using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExitCornerButton : MonoBehaviour
{

    public Button exit;
    // Start is called before the first frame update
    void Start()
    {
        exit = GameObject.FindGameObjectWithTag("exitbutton").GetComponent<Button>();
        exit.onClick.AddListener(Exit);
    }

    void Exit()
    {
        SceneManager.LoadScene(0);
    }
}
