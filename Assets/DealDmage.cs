using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDmage : MonoBehaviour
{
    
    // Start is called before the first frame update
    public void DealDmageToObject(GameObject Player)
    {
        StartCoroutine(DmageTimer(Player));

    }

    public IEnumerator DmageTimer(GameObject Player)
    {
        
        yield return new WaitForSeconds(1f);
        Player.GetComponent<PlayerHP>().DecreasHp();

    }
}
