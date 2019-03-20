using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameObject meleeHit;
    public bool canMelee=true;
    public bool canRange = true;
    public bool swipeSwap;
    private Vector3 rightPos = new Vector3(2f, .3f, 2.5f);
    private Quaternion rightRot = Quaternion.Euler(0, 45, 0);
    private Vector3 leftPos = new Vector3(-2f, .3f, 2.5f);
    private Quaternion leftRot = Quaternion.Euler(0, -45, 0);
    private Vector3 View;
    private Vector3 targetPos;
    private Plane Ground;
    public GameObject rangedProjectile;
    public int Health = 100;
    public int HealthMax = 100;
    public int Gold = 10;
    public GameObject rangedWeapon;
    private int rWloc=0;
    //public CharacterController controller;
    // Start is called before the first frame update
    void Start()
    {
        Ground = new Plane(Vector3.up, Vector3.zero);
        //CharacterController controller = GetComponentInChildren<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Health > HealthMax) Health = HealthMax;
        {
            View = Input.mousePosition;
            Ray mouseCast = Camera.main.ScreenPointToRay(View);
            RaycastHit hit; float rayLength;
            if (Physics.Raycast(mouseCast, out hit, 100))
            {
                targetPos.Set(hit.point.x, 2f, hit.point.z);
            }
            if (Ground.Raycast(mouseCast, out rayLength))
            {
                transform.LookAt(targetPos);
            }
        }
        MoveUpdate();
        if (Input.GetMouseButton(0)&&canMelee) { LMB(); Debug.Log("lmb"); }
        if (Input.GetMouseButton(1) && canRange) { RMB();  }
        if (Input.GetMouseButtonDown(2)) { GameObject.FindGameObjectWithTag("Gate").GetComponent<EnemySpawn>().SpawnBoss(); GameObject.FindGameObjectWithTag("Gate").GetComponent<EnemySpawn>().final = true; }
        if (Health <= 0) SceneManager.LoadScene("GameOver");
    }
    public void LMB()
    {
        meleeHit.SetActive(true);
        if (swipeSwap) { meleeHit.transform.localPosition = rightPos; meleeHit.transform.localRotation = rightRot; }
        else { meleeHit.transform.localPosition = leftPos; meleeHit.transform.localRotation = leftRot; }
        StartCoroutine(Swipe(.2f));
    }
    [HideInInspector]
    public float speedMod=1, meleeSpeed = 400, meleeDamage = 10;
    IEnumerator Swipe(float swipeTime)
    {
        canMelee = false;
        float timer = 0;
        if (swipeSwap)
        {
            while (timer < swipeTime)
            {
                meleeHit.transform.RotateAround(transform.position, Vector3.up, -meleeSpeed * Time.deltaTime);
                timer += Time.deltaTime;
                yield return null;
            }
        }
        else
        {
            while (timer < swipeTime)
            {
                meleeHit.transform.RotateAround(transform.position, Vector3.up, meleeSpeed * Time.deltaTime);
                timer += Time.deltaTime;
                yield return null;
            }
        }
        swipeSwap = !swipeSwap;
        meleeHit.SetActive(false);
        yield return new WaitForSeconds(.5f/speedMod);
        canMelee = true;
    }
    public void RMB()
    {
        Debug.Log("rmb");
        StartCoroutine(Ranged());
    }
    [HideInInspector]
    public float rangedDist = 10, rangedDistGrowth = 10, rangedPower = 1, rangedPowerGrowth = 3, rangedChargeSpeed = .1f,rangedBase=1;
    private int rangedChargeLevel = 1;
    [HideInInspector]
    public int rangedMaxCharge = 3, rangedSpeed = 10;
    IEnumerator Ranged()
    {
        canRange = false;
        bool charge = true;
        float timer = 1;
        while (charge == true)
        {
            rWloc++;
            rangedWeapon.transform.Translate(Vector3.forward*-.1f);
            if (!Input.GetMouseButton(1)) charge = false;
            rangedDist = rangedDistGrowth*rangedChargeLevel;
            rangedPower = rangedPowerGrowth*rangedChargeLevel;
            yield return new WaitForSeconds(rangedChargeSpeed);
            if (rangedChargeLevel > rangedMaxCharge)
            {
                charge = false;               
            }
            rangedChargeLevel=(int)Mathf.Round(timer);
            Debug.Log("charge level "+rangedChargeLevel);
            timer += .1f;
        }
        if (charge == false)
        {
            rangedWeapon.transform.Translate(Vector3.forward * .1f*rWloc);
            rWloc = 0;
            Debug.Log("range power " + rangedPower);
            Debug.Log("bang");
            Instantiate(rangedProjectile,transform.position,Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z));
            yield return new WaitForSeconds(1f);
            canRange = true;
            rangedChargeLevel = 0;
            rangedPower = rangedBase;
            rangedDist = 5;
        }
        yield return null;
    }
    void MoveUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            gameObject.transform.Translate(.25f, 0, 0, Space.World);
        }
        if (Input.GetKey(KeyCode.S))
        {
            gameObject.transform.Translate(-.25f, 0, 0, Space.World);           
        }
        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.Translate(0, 0, .25f, Space.World);
        }
        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.Translate(0, 0, -.25f, Space.World);
        }
        
    }
    void MeleeAttack()
    {

    }
    public void adjustVars(float[] v)
    {
        float HealthChange = v[0], HealthMaxChange = v[1], RangedDamage = v[2], MeleeDamage = v[3];
        Health += (int)HealthChange;
        HealthMax += (int)HealthMaxChange;
        //rangedBase += RangedDamage;
        rangedPowerGrowth += RangedDamage;
        meleeDamage += MeleeDamage;
    }
}
