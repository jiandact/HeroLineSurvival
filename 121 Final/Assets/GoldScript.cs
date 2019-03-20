using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldScript : MonoBehaviour
{
    private string text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().Gold+"";
        gameObject.GetComponent<Text>().text = text;
    }
}
