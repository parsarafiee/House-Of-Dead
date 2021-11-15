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
    public float AnimationTimeToAttack = 2.63f;


    float timerToChargezambi ;
    bool zambiAttackCharged = false;
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
        timerToChargezambi = AnimationTimeToAttack;
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
        if (distanceFromPlayer < distanceToAttack && !isRichedPlayer)
        {
            animator.SetTrigger("attack");
            isRichedPlayer = true;
            zambiAttackCharged = true;


        }
        if (zambiAttackCharged && isAlive)
        {
               timerToChargezambi += Time.deltaTime;
           //ebug.Log(timerToChargezambi);
            if (timerToChargezambi > AnimationTimeToAttack)
            {
                zambiDmage.DealDmageToObject(player.gameObject);
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
