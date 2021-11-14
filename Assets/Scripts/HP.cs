using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour
{

    public int hp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hp<0)
        {
            GameObject.Destroy(gameObject);
        }
        
    }
    public  void  IsDead()
    {
        hp = -1;
    }
    public void DecreaseHP()
    {
        hp -= 1;
    }
}
