using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SquareCode : MonoBehaviour
{
    /*public variables*/
    //...

    /*private variables*/
    [SerializeField]
    private TextMeshPro _lifeText;
    private int health;
    
    private void Awake()
    {
        _lifeText = gameObject.GetComponentInChildren<TextMeshPro>();
    }

    void Start()
    {
        health = Random.Range(1, 5);
        _lifeText.text = health.ToString();
    }

    void Update()
    {
        if (health <= 0)
            Destroy(gameObject, 0.01f);
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ball")
        {
            --health;
            if(health != 0) 
            _lifeText.text = health.ToString();
            if (health <= 0)
                _lifeText.text = "1";
        }
    }

}
