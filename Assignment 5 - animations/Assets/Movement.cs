using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Light light;
    float speed=4;
    float gravity = 8;
    public CharacterController controller;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        light = GetComponentInChildren<Light>();
        controller = GetComponentInChildren<CharacterController>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        float x, y, side, fwd;
        Vector3 rotateValue, moveValue;
        y = Input.GetAxis("Mouse X");
        x = Input.GetAxis("Mouse Y");
        rotateValue = new Vector3(0, y * -1, 0);
        transform.eulerAngles = transform.eulerAngles - rotateValue;
        side = Input.GetAxis("Horizontal");
        fwd = Input.GetAxis("Vertical");
        moveValue = new Vector3(side/3, 0, fwd/3);
        //gameObject.transform.Translate(moveValue);
        gameObject.GetComponent<Rigidbody>().velocity=moveValue*10;

        if (Input.GetKey(KeyCode.W))
        {
            if (anim.GetBool("Attack")) return;
            else
            anim.SetBool("Run", true);
            anim.SetInteger("anim", 1);
            controller.Move((transform.forward * Time.deltaTime) * 4);
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (anim.GetBool("Attack")) return;
            else
                anim.SetBool("Run", true);
            anim.SetInteger("anim", 1);
            controller.Move(((transform.forward*-1) * Time.deltaTime) * 4);
        }
        if (Input.GetKeyUp(KeyCode.W)|| Input.GetKeyUp(KeyCode.S)) { anim.SetInteger("anim", 0); anim.SetBool("Run", false); }
        if (Input.GetMouseButtonDown(0))
        {
            if (anim.GetBool("Run") == true) { anim.SetBool("Run", false);anim.SetInteger("anim",2); }
            else Attack();

        }

    }
    void Attack()
    {
        
        StartCoroutine(AttackRoutine());
        //anim.SetInteger("anim", 0);
    }
    IEnumerator AttackRoutine()
    {
        RaycastHit hit;
        anim.SetBool("Attack", true);
        anim.SetInteger("anim", 2);
        yield return new WaitForSeconds(.5f);
        if (Physics.Raycast(transform.position, transform.forward, out hit, 1))
        {
            if (hit.transform.tag == "Enemy") hit.transform.gameObject.SetActive(false);

        }
        anim.SetInteger("anim", 0);
        anim.SetBool("Attack", false);
    }
}
