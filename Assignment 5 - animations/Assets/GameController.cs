using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int score = 0;
    //public UnityEngine.UI.Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        //scoreText.text = "Items picked up=" + score;
        GameObject.Find("Camera1").GetComponent<Camera>().enabled = true;
        //GameObject.Find("Camera2").GetComponent<Camera>().enabled = false;
        //GameObject.Find("Camera3").GetComponent<Camera>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //scoreText.text = "Items picked up=" + score;
    }

}
