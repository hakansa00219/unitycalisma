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
    private GameObject _obstacleContainer;
    [SerializeField]
    private TextMeshPro _lifeText;

    private int _health;

    private Player _player;
    
    private void Awake()
    {
        _lifeText = gameObject.GetComponentInChildren<TextMeshPro>();
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        _obstacleContainer = GameObject.Find("ObstaclesContainer");
    }

    void Start()
    {
        _health = Random.Range(1, 5);
        _lifeText.text = _health.ToString();
        this.transform.parent = _obstacleContainer.transform;
    }

    void Update()
    {
        if (_health <= 0)
            Destroy(gameObject, 0.01f);
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ball")
        {
            _player.IncreaseMoney();
            --_health;
            if(_health != 0)
            {
                _lifeText.text = _health.ToString();
                
            }
            if (_health <= 0)
                _lifeText.text = "1";

        }
    }

}
