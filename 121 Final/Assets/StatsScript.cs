using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsScript : MonoBehaviour
{
    private string text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        text = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().meleeDamage+"\n" +GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().rangedPowerGrowth + "/" + GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().rangedPowerGrowth * 2 + "/" + GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().rangedPowerGrowth * 3;
        gameObject.GetComponent<Text>().text = text;
    }
}
