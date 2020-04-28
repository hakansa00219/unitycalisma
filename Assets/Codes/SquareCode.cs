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

    private GameDatabase data;
    private float _health;

    private Player _player;
    
    
    private void Awake()
    {
        _lifeText = gameObject.GetComponentInChildren<TextMeshPro>();
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        _obstacleContainer = GameObject.Find("ObstaclesContainer");
        data = GameObject.Find("GameDatabase").GetComponent<GameDatabase>();
    }

    void Start()
    {
        _health = Random.Range(1, 5);
        _lifeText.text = _health.ToString();
        this.transform.parent = _obstacleContainer.transform;
        _lifeText.transform.rotation = Quaternion.Euler(new Vector3(0,0,transform.rotation.z*-1));
        _lifeText.transform.localPosition = new Vector3(0,0,-0.537f);

    }

    void Update()
    {
        if (_health <= 0)
        {
            Destroy(gameObject, 0.01f);
        }
        
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ball")
        {
            
            BallCode ballScript = collision.gameObject.GetComponent<BallCode>();
            
            data.UpgradeMoney(ballScript.Power);

            if (_health > ballScript.Power)
                _health -= ballScript.Power;
            else
                _health = 0;

            if(_health > 0f && _health < 1f)
            {
                _lifeText.text = ":(";
            }
            else if(_health == 0f)
            {
                // ...
            }else
                _lifeText.text = System.Math.Floor(_health).ToString();
                
        }
    }

}
