using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class GameBoardCamScript : MonoBehaviour
{

    public Camera cam1;
    public Camera cam2;
    public Canvas board;
    private BoardGame game;

    // Use this for initialization
    void Start()
    {
        board = GameObject.FindGameObjectWithTag("GameBoard").GetComponentInChildren<Canvas>();
        cam1 = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        cam2 = GameObject.FindGameObjectWithTag("GameBoardCam").GetComponent<Camera>();
        game = GetComponent<BoardGame>();

        GameObject.FindGameObjectWithTag("3x3").GetComponent<Canvas>().enabled = false;
        GameObject.FindGameObjectWithTag("9x9").GetComponent<Canvas>().enabled = false;
        GameObject.FindGameObjectWithTag("6x6").GetComponent<Canvas>().enabled = false;
        GameObject.FindGameObjectWithTag("gamemenu").GetComponent<Canvas>().enabled = false;
        cam2.enabled = false;
        cam2.gameObject.GetComponent<AudioListener>().enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (cam2.enabled)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "FPSController")
        {
            if (Input.GetKey(KeyCode.Return) && !cam2.enabled)
            {
                cam1.enabled = false;
                cam1.gameObject.GetComponent<AudioListener>().enabled = false;
                cam2.gameObject.GetComponent<AudioListener>().enabled = true;
                cam2.enabled = true;
                board.enabled = false;
                game.GetMenu();
                GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>().enabled = false;

            }
            /*if (Input.GetKey(KeyCode.Escape))
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>().enabled = true;
                cam1.gameObject.GetComponent<AudioListener>().enabled = true;
                cam2.gameObject.GetComponent<AudioListener>().enabled = false;
                board.enabled = true;
                cam2.enabled = false;
                cam1.enabled = true;
                game = null;                

            }*/

        }
    }



}
