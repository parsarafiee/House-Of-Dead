using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class EnemyManager : MonoBehaviour
{
    public Transform player;
    public Animator animator;
    public float timeToWalk = 0;
    public float speed;
    public float distanceToAttack;

    float timerToChargezambi = 0;
    bool zambiAttackCharged = true;
    float distanceFromPlayer;
    bool isAlive = true;
    Rigidbody rb;
    HP hp;
    float time;
    bool isRichedPlayer;
    DealDmage zambiDmage;

    // Start is called before the first frame update
    void Start()
    {
        hp = GetComponent<HP>();
        zambiDmage = GetComponent<DealDmage>();
        rb = this.gameObject.GetComponent<Rigidbody>();
        animator.SetInteger("Int", 0);
        //animator = gameObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        distanceFromPlayer = Vector3.Distance(this.transform.position, player.transform.position);
        //Debug.Log(distanceFromPlayer);
        time += Time.deltaTime;
        if (timeToWalk < time && isAlive && !isRichedPlayer)
        {
            animator.SetInteger("Int", 1);
            Vector3 pos = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            rb.MovePosition(pos);
            transform.LookAt(player);
            Debug.Log(distanceFromPlayer);
        }
        if (distanceFromPlayer < distanceToAttack)
        {
            animator.SetTrigger("attack");
            isRichedPlayer = true;
            if (zambiAttackCharged)
            {
                zambiDmage.DealDmageToObject(player.gameObject);
                zambiAttackCharged = false;

            }

        }
        if (!zambiAttackCharged)
        {
            timerToChargezambi += Time.deltaTime;
            Debug.Log(timerToChargezambi);
            if (timerToChargezambi > 1)
            {
                zambiAttackCharged = true;
                timerToChargezambi = 0;
            }
        }


        if (hp.IsDeadBool() && isAlive)
        {
            isAlive = false;
            animator.SetTrigger("dead");
        }




    }
}
