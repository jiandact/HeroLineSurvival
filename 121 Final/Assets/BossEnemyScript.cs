using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BossEnemyScript : MonoBehaviour
{
    public GameObject enemy;
    public int Health = 500;
    public bool EnemyFound = false;
    public GameObject Target;
    public Vector3 Destination;
    private bool canAttack = true;
    public ParticleSystem attpart;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnEnable()
    {
        Target = GameObject.FindGameObjectWithTag("Shop");
        Destination = Target.transform.position;
        //StartCoroutine(SpawnMinion());
    }
    public void switchTarget(GameObject newtarget)
    {
        Target = newtarget;
        Destination = Target.transform.position;
    }
    IEnumerator Attack()
    {
        attpart.Play();
        canAttack = false;
        yield return new WaitForSeconds(.2f);
        if (Vector3.Distance(gameObject.transform.position, player.transform.position) < 9)
        {
            player.GetComponent<PlayerController>().Health -= 10;
        }
        yield return new WaitForSeconds(.5f);
        canAttack = true;
    }
    IEnumerator SpawnMinion()
    {
        Debug.Log("3");
        Instantiate(enemy, gameObject.transform.position, Quaternion.Euler(gameObject.transform.forward));
        yield return new WaitForSeconds(3f);
        SpawnMinion();
    }
    // Update is called once per frame
    void Update()
    {
        if (Health <= 0)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().Gold += 10000;
            Destroy(this.gameObject);
        }
        if (canAttack) StartCoroutine(Attack());
        gameObject.transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, 2f*Time.deltaTime);
        gameObject.transform.LookAt(2 * gameObject.transform.position - Target.transform.position);
        if (Vector3.Distance(gameObject.transform.position, Target.transform.position) < 9) SceneManager.LoadScene("GameOver");
    }
}
