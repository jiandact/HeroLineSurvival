using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeHitbox : MonoBehaviour
{
    private int power;
    // Start is called before the first frame update
    void Start()
    {
        power = Mathf.RoundToInt(GetComponentInParent<PlayerController>().meleeDamage);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" && other.GetComponent<BossEnemyScript>()) other.GetComponent<BossEnemyScript>().Health -= power;
        else
        {
            other.GetComponent<Rigidbody>().AddForce(GetComponentInParent<Transform>().forward, ForceMode.Impulse);
            other.GetComponent<EnemyController>().Health -= power;
            Debug.Log("enemy hit");
            Debug.Log(other.GetComponent<EnemyController>().Health);
        }
    }
}
