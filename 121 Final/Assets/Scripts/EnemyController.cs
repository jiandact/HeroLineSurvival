using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int Health=20;
    public bool EnemyFound = false;
    public GameObject Target;
    public Vector3 Destination;
    private bool canAttack = true;
    public ParticleSystem attpart;
    // Start is called before the first frame update
    void Start()
    {
    
    }
    private void OnEnable()
    {
        Health = (int)Mathf.Round(25 + (1/4 * (Time.time)));
        Destination = Target.transform.position;
    }
    public void switchTarget(GameObject newtarget)
    {
        Target = newtarget;
        Destination = Target.transform.position;
    }
    IEnumerator Attack(GameObject newtarget)
    {
        attpart.Play();
        canAttack = false;
        Debug.Log("enemy attacks!");
        yield return new WaitForSeconds(.2f);
        if (Vector3.Distance(gameObject.transform.position, Target.transform.position) < 5)
        {
            newtarget.GetComponent<PlayerController>().Health -= 5;
            Debug.Log("enemy hits!");
        }
        else Debug.Log("enemy miss!");
        yield return new WaitForSeconds(.8f);
        canAttack = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (Health <= 0)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().Gold += 1+((int)Time.time/10);
            Destroy(this.gameObject);
        }
        if (Vector3.Distance(gameObject.transform.position, Target.transform.position) < 5 && canAttack) StartCoroutine(Attack(Target));
        else if (Vector3.Distance(gameObject.transform.position, Target.transform.position) < 5) ;
        else gameObject.transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, 5f * Time.deltaTime);
        gameObject.transform.LookAt(2*gameObject.transform.position-Target.transform.position);
    }
}
