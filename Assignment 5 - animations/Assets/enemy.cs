using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public GameObject target;
    public bool range = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (range)
        {
            transform.LookAt(target.transform.position);
            transform.position += transform.forward*(Time.deltaTime+.1f);
        }

    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") range = true;
    }
}
