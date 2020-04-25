using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCreatorCode : MonoBehaviour
{
    public GameObject loc;

    public GameObject[] spherePrefab;

    private Transform locT;


    private int seconds;
    private float timer;
    private float mseconds;

    List<GameObject> mylist;
    public int idx;
    // Start is called before the first frame update
    void Start()
    {
        locT = loc.GetComponent<Transform>();
        mylist = new List<GameObject>();
        mseconds = 5;
        StartCoroutine(Spawn());

        InvokeRepeating("timedivider", 5, 2);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    IEnumerator Spawn()
    {
        while(true)
        {
           
            int x = Random.Range(0, 299);
            float randX = Random.Range(-3f, 3f);


            Instantiate(spherePrefab[x / 100], new Vector3(randX, locT.position.y, locT.position.z), Quaternion.identity);
            
            Debug.Log(mylist.Count + ". block created.");
            yield return new WaitForSeconds(mseconds);
        }
        
    }

    void timedivider()
    {
        mseconds /= 2;
    }

}
