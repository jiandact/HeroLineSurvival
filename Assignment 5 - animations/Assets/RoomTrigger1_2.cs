using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTrigger1_2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter()
    {
        Debug.Log("trigger enter");
        if (GameObject.Find("Camera2").GetComponent<Camera>().enabled==false)
        {
            Debug.Log("if");
            GameObject.Find("Camera1").GetComponent<Camera>().enabled = false;
            GameObject.Find("Camera2").GetComponent<Camera>().enabled = true;
            GameObject.Find("Camera3").GetComponent<Camera>().enabled = false;
            //setActive
        }
        else if (GameObject.Find("Camera1").GetComponent<Camera>().enabled == false)
        {
            Debug.Log("if2");
            GameObject.Find("Camera1").GetComponent<Camera>().enabled = true;
            GameObject.Find("Camera2").GetComponent<Camera>().enabled = false;
            GameObject.Find("Camera3").GetComponent<Camera>().enabled = false;
        }
    }
}
