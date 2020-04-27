using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCode : MonoBehaviour
{
    [SerializeField]
    private float _power;
    [SerializeField]
    private float _life;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.localScale *= 2;
        this._power = 1;
        this._life = 5;
    }

    private void Update()
    {
        if(_life <= 0)
        {
            Destroy(gameObject,0.01f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            this._life--;

        }
    }
}
