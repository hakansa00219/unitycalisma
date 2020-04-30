using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericObstacle : MonoBehaviour
{
    //*Public*\\
    public float health;
    //*Private*\\
    [SerializeField]
    private TMPro.TextMeshPro _lifeText;

    private GameDatabase data;

    private void Awake()
    {
        _lifeText = gameObject.GetComponentInChildren<TMPro.TextMeshPro>();
        data = GameObject.Find("GameDatabase").GetComponent<GameDatabase>();
    }

    // Start is called before the first frame update
    void Start()
    {
        this.health = System.Convert.ToInt16(_lifeText.text);
    }

    // Update is called once per frame
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

            if (health > 0f && health < 1f)
            {
                _lifeText.text = ":(";
            }
            else if (health == 0f)
            {
                // ...
            }
            else
                _lifeText.text = System.Math.Floor(health).ToString();

        }
    }
}
