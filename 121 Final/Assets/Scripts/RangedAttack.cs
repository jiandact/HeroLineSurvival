using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour
{
    public int power;
    public int speed;
    public int distance;
    public int pierce=0;
    // Start is called before the first frame update
    void Start()
    {
        power = Mathf.RoundToInt(GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().rangedPower);
        speed = Mathf.RoundToInt(GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().rangedSpeed);
        distance = Mathf.RoundToInt(GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().rangedDist);
    }
    
    // Update is called once per frame
    void Update()
    {
        if (distance > 0) gameObject.transform.Translate(GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().forward * speed*Time.deltaTime*3f, Space.Self);
        else Destroy(this.gameObject);
        distance--;
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ranged hit");
        if (other.tag == "Enemy" && other.GetComponent<BossEnemyScript>()) other.GetComponent<BossEnemyScript>().Health -= power;
        else if (other.tag == "Enemy"&&pierce<=0)
        {
            Debug.Log("ranged enemy hit");
            Debug.Log(other.GetComponent<EnemyController>().Health);
            other.GetComponent<EnemyController>().Health -= power;
            Destroy(this.gameObject);
        }
    }
}
