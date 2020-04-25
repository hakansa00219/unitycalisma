using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareCode : MonoBehaviour
{
    private int x = 0;
    private int health;
    // Start is called before the first frame update
    void Start()
    {
        health = Random.Range(1, 3);
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
            Destroy(gameObject, 0.1f);
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ball")
        {
            --health;
        }
    }

}
