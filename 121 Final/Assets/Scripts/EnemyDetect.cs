using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetect : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (GetComponentInParent<EnemyController>().EnemyFound == false)
        {
            if (GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position.x - gameObject.transform.position.x < 20
            && GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position.z - gameObject.transform.position.z < 20) GetComponentInParent<EnemyController>().EnemyFound = true;
        }
        if (GetComponentInParent<EnemyController>().EnemyFound == true) GetComponentInParent<EnemyController>().Target = GameObject.FindGameObjectWithTag("Player");
        */
        if (Vector3.Distance(GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position, gameObject.transform.position) < 20)
            GetComponentInParent<EnemyController>().Target = GameObject.FindGameObjectWithTag("Player");
    }
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("enemy detect range enter");
        GetComponentInParent<EnemyController>().EnemyFound = true;
        GetComponentInParent<EnemyController>().switchTarget(other.gameObject);
    }
}
