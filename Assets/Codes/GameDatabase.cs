using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class GameDatabase : MonoBehaviour
{
    /*Ball data*/
    private float _ballPower;
    private int _ballLife = 1;
    /*Spawner data*/
    private float _spawnRate;
    private int _ballSpawnCount;
    /*Player data*/
    private float _money;
    [SerializeField]
    private TextMeshProUGUI moneyText;
    [SerializeField]
    private TextMeshProUGUI[] _textArr;


    private void Update()
    {
        UpdateTexts();
    }

    public void UpdateTexts()
    {
        string moneyTextCnv = System.String.Format("{0:0.##}", (float)System.Math.Round(_money, 2));
        moneyText.text = "$: " + moneyTextCnv;
        _textArr[0].text = System.String.Format("{0:0.##}", _ballPower);
        _textArr[2].text = System.String.Format("{0:0.##}", _spawnRate);
        _textArr[1].text = _ballLife.ToString();
        _textArr[3].text = _ballSpawnCount.ToString();
    }

    private void Start()
    {
        /*Initialize datas*/
        InitializeBallInfo();
        InitializeSpawnerInfo();
        
    }
    
    /*Initializers*/
    void InitializeBallInfo()
    {
        _ballPower = 1.0f;
        _ballLife = 5;
    }

    void InitializeSpawnerInfo()
    {
        _spawnRate = 0.01f;
        _ballSpawnCount = 1;
    }

    /*Setters*/
    public void UpgradeBallPower(){ _ballPower += 1.0f; _money -= 10f; }
    public void UpgradeBallLife() { _ballLife += 1; _money -= 10f; }
    public void UpgradeSpawnRate() { _spawnRate += 0.01f; _money -= 5f; }
    public void UpgradeBallSpawnCount() { _ballSpawnCount += 1; _money -= 500f; }
    public void UpgradeMoney(float money) { _money += money; }
    /*Getters*/
    public float GetBallPower() { return _ballPower; }
    public int GetBallLife() { return _ballLife; }
    public float GetSpawnRate() { return _spawnRate; }
    public int GetBallSpawnCount() { return _ballSpawnCount; }
    public float GetMoney() { return _money; }
}
