using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public Transform player;
    Vector3 pos;
    float a, b, c;
    // Start is called before the first frame update
    void Start()
    {
        a = gameObject.transform.position.x;
        b = gameObject.transform.position.y;
        c = player.position.z;
        pos = new Vector3(a,b,c);
    }

    // Update is called once per frame
    void Update()
    {
        c = player.position.z;
        pos.Set(a, b, c);
        gameObject.transform.position=pos;
    }
}
