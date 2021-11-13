using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class EnemyManager : MonoBehaviour
{
    public Animator animator;
    public float timeToWalk=0;

    float time;

    // Start is called before the first frame update
    void Start()
    {
        animator.SetInteger("Int", 0);
        //animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        time+= Time.deltaTime;
        if (timeToWalk < time)
        {
            animator.SetInteger("Int", 1);

        }
        
    }
}
