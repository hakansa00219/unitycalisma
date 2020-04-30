using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameDatabase data;
    public BallCode ballCode;
    public BallCreatorCode ballSpawner;
    public loadingbar loadingbar;
    public Button[] buttons;

    private float _currentMoney;
    private void Update()
    {
        //Check buttons if money is enough to buy.
        ButtonConfig();          
    }

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
        data.UpgradeSpawnRate();
        //informballspawner
        loadingbar.UpgradeSpawnRate();
    }
    public void UpgradeSpawnCount()
    {
        //updatedatabase
        data.UpgradeBallSpawnCount();
        //informballspawner
        ballSpawner.UpgradeSpawnCount();
    }
    private void ButtonConfig()
    {
        _currentMoney = data.GetMoney();
        if (_currentMoney < 10f)
        {
            buttons[0].interactable = false;
        }
        else
        {
            buttons[0].interactable = true;
        }

        if (_currentMoney < 10f)
        {
            buttons[1].interactable = false;
        }
        else
        {
            buttons[1].interactable = true;
        }
        if (_currentMoney < 5f)
        {
            buttons[2].interactable = false;
        }
        else
        {
            buttons[2].interactable = true;
        }
        if (_currentMoney < 500f)
        {
            buttons[3].interactable = false;
        }
        else
        {
            buttons[3].interactable = true;
        }

    }
}
