using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    
    public Camera TPP;
    public Camera FPP;
    private bool binary=true;
    // Start is called before the first frame update
    void Start()
    {
        TPP.enabled = false;
        FPP.enabled = true;

    }

    void onClick()
    {
        if (binary)
        {
            Debug.Log("1");
            TPP.enabled = false;
            FPP.enabled = true;
            binary = false;
        }
        else
        {
            Debug.Log("2");
            TPP.enabled = true;
            FPP.enabled = false;
            binary = true;
        }
    }
}
