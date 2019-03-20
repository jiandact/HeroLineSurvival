using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public GameObject player;
    public Vector3 playerLoc;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerLoc.Set(player.transform.position.x-30,gameObject.transform.position.y,player.transform.position.z);
        gameObject.transform.SetPositionAndRotation(playerLoc,gameObject.transform.rotation);
    }
}
