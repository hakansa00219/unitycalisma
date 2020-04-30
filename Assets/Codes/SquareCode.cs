using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SquareCode : MonoBehaviour
{
    /*public variables*/
    //...
    public float health;

    /*private variables*/
    private GameObject _obstacleContainer;
    [SerializeField]
    private TextMeshPro _lifeText;

    private GameDatabase data;

    
    
    private void Awake()
    {
        _lifeText = gameObject.GetComponentInChildren<TextMeshPro>();
        _obstacleContainer = GameObject.Find("ObstaclesContainer");
        data = GameObject.Find("GameDatabase").GetComponent<GameDatabase>();
    }

    void Start()
    {
        this.health = Random.Range(1, 10);
        _lifeText.text = health.ToString();
        this.transform.parent = _obstacleContainer.transform;

    }

    void Update()
    {
        if (health <= 0)
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

            if (health > ballScript.Power)
                health -= ballScript.Power;
            else
                health = 0;

            if(health > 0f && health < 1f)
            {
                _lifeText.text = ":(";
            }
            else if(health == 0f)
            {
                // ...
            }else
                _lifeText.text = System.Math.Floor(health).ToString();
                
        }
    }

}
