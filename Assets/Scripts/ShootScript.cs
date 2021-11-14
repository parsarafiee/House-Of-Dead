using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    public Camera cam;
    Magazine magazine;
    Laser laser;
    // Start is called before the first frame update
    void Start()
    {
        magazine = GetComponent<Magazine>();
        laser = GetComponent<Laser>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            magazine.DecreasBullet()
            Ray r = cam.ScreenPointToRay(Input.mousePosition);

           
            RaycastHit rch;
            if (Physics.Raycast(r,out rch))  
            {
                

                Bleeding sprayblood = rch.rigidbody.GetComponent<Bleeding>();
                 
                Bleeding coll = rch.collider.GetComponent<Bleeding>();
                Debug.Log(coll.name);
                if (coll.name =="Zombie:Head")
                {
                    HP hp=coll.GetComponentInParent<HP>();
                    hp.IsDead();
                }
                if (sprayblood)
                {
                    laser.ShootSpot(rch.point);
                    sprayblood.ShootSpot(rch.point,rch.normal);
                }

            }
        }
    }
}
