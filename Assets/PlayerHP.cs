using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    List<GameObject> heartsList;
    public Transform hpPanel;
    public GameObject heart;
    public int numberOfHeart = 5;


    void Start()
    {
        heartsList = new List<GameObject>();
        RechargeHP();
    }
    public void RechargeHP()
    {
        heartsList.Clear();
        for (int i = 0; i < numberOfHeart; i++)
        {
            GameObject bul = GameObject.Instantiate(heart, hpPanel.transform);
            heartsList.Add(bul);
        }
    }

    public void DecreasHp()
    {
        GameObject.Destroy(heartsList[0]);
        heartsList.Remove(heartsList[0]);

    }
    public int NumberOfBulletsLeft()
    {
        return heartsList.Count;
    }
}
