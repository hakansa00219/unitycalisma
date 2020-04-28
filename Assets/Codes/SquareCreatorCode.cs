using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareCreatorCode : MonoBehaviour
{
    /*Public variables*/
    public GameObject square;
    public GameObject[] squarePrefab;
    
    /*Private variables*/
    private Transform locT;
    /*Columns*/
    private float[] xArr = { -4.5f, -3f, -1.5f, 0 , 1.5f, 3f, 4.5f };
    private int squareColCnt;
    /*Rows*/
    private float[] yArr = { 4, 2.5f, 1, -0.5f, -2};
    private int squareRowCnt;

    private bool spawnCoroutineActive;
    private IEnumerator spawnCoroutine;

    void Start()
    {
        squareColCnt = xArr.Length;
        squareRowCnt = yArr.Length;
        spawnCoroutineActive = false;
        spawnCoroutine = SpawnNewSquare();

        locT = square.GetComponent<Transform>();

        /*Instantiate blocks*/
        for (int y = 0; y < squareRowCnt; ++y)
        {
            for (int x = 0; x < squareColCnt; ++x)
            {
                int rnd = Random.Range(0, squarePrefab.Length);
                if(rnd == 0)
                {
                    GameObject obj = Instantiate(squarePrefab[rnd],
                    new Vector3(xArr[x], yArr[y], locT.position.z),
                    Quaternion.Euler(new Vector3(0, 0, Random.Range(0,4)*90)));
                } else
                {
                    GameObject obj = Instantiate(squarePrefab[rnd],
                    new Vector3(xArr[x], yArr[y], locT.position.z),
                    Quaternion.Euler(new Vector3(0, 0, Random.Range(0,2)*45)));
                }
                
                
            }
        }
    }

    void Update()
    {
        /*Hysterisys between 10-20*/
        if (!spawnCoroutineActive)
        {
            if (SquareContainerCode.squareCnt < 10)
            {
                StartCoroutine(spawnCoroutine);
                spawnCoroutineActive = true;
                Debug.Log("Coroutine active.!");
            }
        }
        else
        {
            if (SquareContainerCode.squareCnt > 20)
            {
                Debug.Log("Coroutine durduuuuuuuuuuuuu.!");
                StopCoroutine(spawnCoroutine);
                spawnCoroutineActive = false;
            }
        }

        
    }

    IEnumerator SpawnNewSquare()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);
            /*Spawn on random point*/
            Instantiate(squarePrefab[Random.Range(0, squarePrefab.Length)],
                new Vector3(xArr[Random.Range(0, squareColCnt)], yArr[Random.Range(0, squareRowCnt)],
                locT.position.z), Quaternion.identity);

            Debug.Log("Spawned.!!!!!!!!!");
            Debug.Log("Count: " + SquareContainerCode.squareCnt);
        }
    }
}   
