using UnityEngine;
using System.Collections;

public class GameBook2CamScript : MonoBehaviour
{

    Camera cam1;
    Camera cam2;

    // Use this for initialization
    void Start()
    {
        cam1 = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        cam2 = GameObject.FindGameObjectWithTag("GameBook2Cam").GetComponent<Camera>();
        cam2.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "FPSController")
        {
            if (Input.GetKey(KeyCode.Return) && !cam2.enabled)
            {
                cam1.enabled = false;
                cam2.enabled = true;
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
            }
            if (Input.GetKey(KeyCode.Escape))
            {
                cam2.enabled = false;
                cam1.enabled = true;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }

        }

    }


}
