using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterInTheHall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
  void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "FPSController")
        {
            if (Input.GetKey(KeyCode.Return))
            {
                SceneManager.LoadScene(1);
            }
        }
    }
}
