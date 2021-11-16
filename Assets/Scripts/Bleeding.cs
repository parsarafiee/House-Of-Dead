using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bleeding : MonoBehaviour
{
    public GameObject spray;

    HP hp;

    // Start is called before the first frame update
    void Start()
    {
        hp = gameObject.GetComponent<HP>();
    }
    public void ShootSpot(Vector3 pos, Vector3 normal)
    {

        Debug.Log("hi");
        StartCoroutine(BloodSprayEffect(pos, normal));
    }
    
    public IEnumerator BloodSprayEffect(Vector3 pos, Vector3 normal)
    {
        hp.DecreaseHP();
        GameObject spraypref = GameObject.Instantiate(spray, pos,Quaternion.identity,transform);
        spraypref.transform.LookAt(normal);
        yield return new WaitForSeconds(0.3f);
        GameObject.Destroy(spraypref);
       // GameObject spray = GameObject.Instantiate(spray, pos, Quaternion.identity);

    }


}
