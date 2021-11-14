using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    LineRenderer laser;
    void Start()
    {
        laser = GetComponent<LineRenderer>();
        laser.SetPosition(0, this.transform.position);
    }

    public void ShootSpot(Vector3 pos)
    {
        StartCoroutine(LaserEffect(pos));

    }

    public IEnumerator LaserEffect(Vector3 pos)
    {
        laser.SetPosition(1, pos);
        yield return new WaitForSeconds(0.2f);
        laser.SetPosition(1, this.transform.position);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
