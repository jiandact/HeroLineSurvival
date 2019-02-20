using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject door;
    public ParticleSystem collect;
    // Start is called before the first frame update
    void Start()
    {
        collect = gameObject.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(transform.position.x, Mathf.Sin(Time.time*2)/2, transform.position.z);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject.Find("GameObject").GetComponent<GameController>().score += 1;
            collect.Play(); //.SetActive(true);
            Delay();
            door.transform.position += new Vector3(0, 10, 0);
        }
    }
    IEnumerable Delay()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
    }
}
