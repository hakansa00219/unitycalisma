using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _money = 0;
    [SerializeField]
    private TextMeshProUGUI moneyText;

    // Update is called once per frame
    void Update()
    {
        string moneyTextCnv = System.String.Format("{0:0.##}", _money);
        moneyText.text = "$: " + moneyTextCnv;
    }

    public void IncreaseMoney(float delta)
    {
        _money += (float)System.Math.Round(delta, 2);
    }
}
