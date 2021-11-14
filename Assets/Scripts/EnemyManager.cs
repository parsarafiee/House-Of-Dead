using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class EnemyManager : MonoBehaviour
{
    public Transform player;
    public Animator animator;
    public float timeToWalk=0;
    public float speed;

    bool isAlive = true;
    Rigidbody rb;
    HP hp;
    float time;

    // Start is called before the first frame update
    void Start()
    {
        hp = GetComponent<HP>();
        rb = this.gameObject.GetComponent<Rigidbody>();
        animator.SetInteger("Int", 0);
        //animator = gameObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        
        time+= Time.deltaTime;
        if (timeToWalk < time && isAlive)
        {
            animator.SetInteger("Int", 1);
            Vector3 pos = Vector3.MoveTowards(transform.position, player.position, speed*Time.deltaTime) ;
            rb.MovePosition(pos);
            transform.LookAt(player);
         }
        if (hp.IsDeadBool ()&& isAlive)
        {
            isAlive = false;
            animator.SetTrigger("dead");
        }




    }
}
