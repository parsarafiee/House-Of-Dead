using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Magazine : MonoBehaviour
{

    List<GameObject> magazine;
    public Transform magazinePanel;
    public GameObject bullet;
    public int numberOfBullet=5;


    void Start()
    {
        magazine = new List<GameObject>();
        FedBullet();
    }
    public void FedBullet()
    {
        magazine.Clear();
        for (int i = 0; i < numberOfBullet; i++)
        {
            GameObject bul = GameObject.Instantiate(bullet, magazinePanel.transform);
            magazine.Add(bul);
        }
    }

    public void DecreasBullet()
    {
        GameObject.Destroy(magazine[0]);
        magazine.Remove(magazine[0]);

    }
    public int NumberOfBulletsLeft()
    {
        return magazine.Count;
    }
   
    void Update()
    {
        
    }
}
