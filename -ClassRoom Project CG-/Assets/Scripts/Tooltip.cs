using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour
{

    private Canvas ttcanvas;
    private Text tttext;
    public string instruction;

    // Use this for initialization
    void Start()
    {

        ttcanvas = GameObject.FindGameObjectWithTag("tooltipcanvas").GetComponent<Canvas>();
        tttext = GameObject.FindGameObjectWithTag("tooltiptext").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "FPSController")
        {
            tttext.text = instruction;
            ttcanvas.enabled = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        new WaitForSecondsRealtime(5000);
        ttcanvas.enabled = false;
    }
}
