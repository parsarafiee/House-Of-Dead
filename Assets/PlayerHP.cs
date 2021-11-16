using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    List<GameObject> heartsList;
    public Transform hpPanel;
    public GameObject heart;
    public int numberOfHeart = 5;
     float timeToFall=0;
    GameManager gameManager;
    bool isAlive;


    

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        heartsList = new List<GameObject>();
        RechargeHP();
    }
    private void Update()
    {
        int numberOfHeartLeft = NumberOfBulletsLeft();
        if (numberOfHeartLeft<1 )
        {
            timeToFall += Time.deltaTime;
            //gameManager.GameIsDone();
            this.gameObject.transform.rotation = new Quaternion(Mathf.Lerp( 0,-90, timeToFall / 10), 0, 0,0);
            
        }


    }
    public void RechargeHP()
    {
        heartsList.Clear();
        for (int i = 0; i < numberOfHeart; i++)
        {
            GameObject playerHeart = GameObject.Instantiate(heart, hpPanel.transform);
            heartsList.Add(playerHeart);
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
