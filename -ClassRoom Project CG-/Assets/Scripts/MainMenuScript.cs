using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour {

    private Button play, hplay, hback, help, exit;
    private Canvas menu, helpp;
    // Use this for initialization
    void Start ()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;

        menu = GameObject.FindGameObjectWithTag("menupanel").GetComponent<Canvas>();
        helpp = GameObject.FindGameObjectWithTag("helppanel").GetComponent<Canvas>();

        play = GameObject.FindGameObjectWithTag("play").GetComponent<Button>();
        hplay = GameObject.FindGameObjectWithTag("hplay").GetComponent<Button>();
        hback = GameObject.FindGameObjectWithTag("hback").GetComponent<Button>();
        help = GameObject.FindGameObjectWithTag("help").GetComponent<Button>();
        exit = GameObject.FindGameObjectWithTag("exit").GetComponent<Button>();

        play.onClick.AddListener(Play);
        hplay.onClick.AddListener(Play);
        hback.onClick.AddListener(Back);
        exit.onClick.AddListener(Exit);
        help.onClick.AddListener(Help);
        helpp.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void Back()
    {
        menu.enabled = true;
        helpp.enabled = false;
    }

    void Help()
    {
        menu.enabled = false;
        helpp.enabled = true;
    }

    void Play()
    {
        SceneManager.LoadScene(1);
    }

    void Exit()
    {
        Application.Quit ();
    }

}
