using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemy;
    public GameObject Boss;
    Vector3 spawnPoint;
    private int breakpoint=0;
    int wave=0;
    int enemyAmount=1;
    public bool final=false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }
    void spawnPointRandom()
    {
        spawnPoint.x = Random.Range(-20f, 20f);
        spawnPoint.y = gameObject.transform.position.y+5;
        spawnPoint.z = Random.Range(20f, 25f);
        if (final == true)
        {
            spawnPoint.x = Boss.transform.position.x + Random.Range(-3f, 3f);
            spawnPoint.y = Boss.transform.position.y;
            spawnPoint.z = Boss.transform.position.z+Random.Range(2f,7f);
        }
    }
    // Update is called once per frame
    void Update()
    {
        //random x 3,-3, z 132 130

    }
    IEnumerator Spawn()
    {
        if (final == false)
        {
            Debug.Log("Enemy spawn");
            Debug.Log("Enemy HP " + enemy.GetComponent<EnemyController>().Health);
            spawnPointRandom();
            Instantiate(enemy, spawnPoint, Quaternion.Euler(gameObject.transform.forward));
            yield return new WaitForSeconds(2f);
            breakpoint++;
            if (breakpoint == enemyAmount)
            {
                wave++;
                yield return new WaitForSeconds(8f);
                breakpoint = 0;
                enemyAmount += 2;
                if (enemyAmount >= 10)
                {
                    
                    SpawnBoss();                   
                    yield return null;
                    
                }
            }
            StartCoroutine(Spawn());
        }
    }
    IEnumerator SpawnMinion()
    {
        Debug.Log("2");
        Debug.Log("Enemy spawn");
        Debug.Log("Enemy HP " + enemy.GetComponent<EnemyController>().Health);
        spawnPointRandom();
        Instantiate(enemy, spawnPoint, Quaternion.Euler(gameObject.transform.forward));
        yield return new WaitForSeconds(3f);
        StartCoroutine(SpawnMinion());
    }
    public void SpawnBoss()
    {
        final = true;
        Instantiate(Boss, spawnPoint, Quaternion.Euler(gameObject.transform.forward));
        Debug.Log("1");
        StartCoroutine(SpawnMinion());
    }
}
