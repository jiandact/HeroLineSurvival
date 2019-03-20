using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    private bool inRange;
    private string text;
    public GameObject shopui;
    //private Dictionary<string,float[]> itemList=new Dictionary<string, float[]>();

    private List<float[]> itemList = new List<float[]>(5);

    void Start()
    {
        itemList.Add(new float[5] { 0, 0, 0, 10, 10 });//melee dmg
        itemList.Add(new float[5] { 25, 0, 0, 0, 10 });//heal
        itemList.Add(new float[5] { 0, 0, 2, 0, 10 });//ranged dmg
        itemList.Add(new float[5] { 25, 25, 0, 0, 20 });//max hp up
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange)
        {
            Shopping();
            //GameObject.FindGameObjectWithTag("uitext").SetActive(true);
            shopui.SetActive(true);
        }
    }
    private void Shopping()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)&&inRange)
        {
            Buy(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && inRange)
        {
            Buy(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && inRange)
        {
            Buy(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && inRange)
        {
            Buy(3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5) && inRange)
        {
            Buy(4);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            inRange = true;
            Debug.Log(inRange);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            inRange = false;
            shopui.SetActive(false);
            Debug.Log(inRange);
        }
    }
    void Buy(int itemNum)
    {
        Debug.Log(itemList[itemNum]);
        if (itemList[itemNum][4] > GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().Gold) Debug.Log("not enough minerals");
        else
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().adjustVars(itemList[itemNum]);
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().Gold -= (int)itemList[itemNum][4];
        }
    }
}
