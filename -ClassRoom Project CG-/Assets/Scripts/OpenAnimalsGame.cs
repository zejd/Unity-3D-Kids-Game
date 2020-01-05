using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenAnimalsGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnTriggerStay(Collider other)
    {
            if (other.gameObject.name == "FPSController")
            {
                if (Input.GetKey(KeyCode.Return))
                {
                    SceneManager.LoadScene(3);
                }
            }
    }
}
