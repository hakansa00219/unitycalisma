using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameDatabase data;
    public BallCode ballCode;
    public BallCreatorCode ballSpawner;

    public void UpgradeBallPower()
    {
        //updatedatabase
        data.UpgradeBallPower();
        //inform ballcode
        GameObject[] balls = GameObject.FindGameObjectsWithTag("ball");
        if(balls.Length > 0)
        {
            foreach (GameObject ball in balls)
            {
                ball.GetComponent<BallCode>().UpdateYourself(data);

            }
        }
    }

    public void UpgradeBallLife()
    {
        //updatedatabase
        data.UpgradeBallLife(); 
        //inform ballcode
        //ballCode.UpdateYourself(); no need?
    }

    public void UpgradeSpawnRate()
    {
        //updatedatabase
        //informballspawner
    }
    public void UpgradeSpawnCount()
    {
        //updatedatabase
        //informballspawner
    }

}
