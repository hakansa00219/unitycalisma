using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCode : MonoBehaviour
{
    private GameDatabase data;
    [SerializeField]
    private float _power;
    [SerializeField]
    private int _life = 1;
    private int x = 1;

    // Start is called before the first frame update

    public float Power { get { return _power; } }
    public float Life { get { return _life; } }

    private void Awake()
    {
        data = GameObject.FindGameObjectWithTag("Database").GetComponent<GameDatabase>();
    }
    void Start()
    {
        _power = data.GetBallPower();
        _life = data.GetBallLife();
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

    public void UpdateYourself(GameDatabase database)
    {
        x = 0;
        Debug.Log(database.GetBallPower());
        //databasele haberleş
        this._power = database.GetBallPower();
        this._life = database.GetBallLife();

    }
}
