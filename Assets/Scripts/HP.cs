using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour
{

    public int hp;
    public bool isDead;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hp<0)
        {
            isDead = true;
        }
        
    }
    public  void  IsDead()
    {
        hp = -1;
        isDead = true;
    }
    public bool IsDeadBool()
    {
        return isDead;
    }
    public void DecreaseHP()
    {
        hp -= 1;
    }
}
