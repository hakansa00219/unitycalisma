using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareCreatorCode : MonoBehaviour
{
    /*Public variables*/
    public GameObject squareSpawnPoint;
    public GameObject[] trianglesPrefab;
    public GameObject[] squarePrefab;

    
    /*Private variables*/
    private Transform locT;
    /*Columns*/
    private float[] xArr = { -4.5f, -3f, -1.5f, 0 , 1.5f, 3f, 4.5f };
    private int squareColCnt;
    /*Rows*/
    private float[] yArr = { 4, 2.5f, 1, -0.5f, -2};
    private int squareRowCnt;
    private int rndTriSqu;
    private int rndTriangles;
    private int rndSquares;
    private bool spawnCoroutineActive;
    private IEnumerator spawnCoroutine;
    private void Awake()
    {
        locT = squareSpawnPoint.GetComponent<Transform>();
    }
    void Start()
    {
        
        squareColCnt = xArr.Length;
        squareRowCnt = yArr.Length;
        spawnCoroutineActive = false;
        spawnCoroutine = SpawnNewSquare();

        

        /*Instantiate blocks*/
        for (int y = 0; y < squareRowCnt; ++y)
        {
            for (int x = 0; x < squareColCnt; ++x)
            {
                rndTriSqu = Random.Range(0, 2);
                rndTriangles = Random.Range(0, 4);
                rndSquares = Random.Range(0, 2);
                if(rndTriSqu == 0)
                {
                    Instantiate(trianglesPrefab[rndTriangles],
                    new Vector3(xArr[x], yArr[y], locT.position.z),
                    trianglesPrefab[rndTriangles].transform.rotation);

                } else if(rndTriSqu == 1)
                {
                    Instantiate(squarePrefab[rndSquares],
                    new Vector3(xArr[x], yArr[y], locT.position.z),
                    squarePrefab[rndSquares].transform.rotation);
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
            rndTriSqu = Random.Range(0, 2);
            rndTriangles = Random.Range(0, 4);
            rndSquares = Random.Range(0, 2);
            if (rndTriSqu == 0)
            {
                Instantiate(trianglesPrefab[rndTriangles],
                new Vector3(xArr[Random.Range(0, squareColCnt)], yArr[Random.Range(0, squareRowCnt)],locT.position.z),
                trianglesPrefab[rndTriangles].transform.rotation);
            } else if (rndTriSqu == 1)
            {
                Instantiate(squarePrefab[rndSquares],
                new Vector3(xArr[Random.Range(0, squareColCnt)], yArr[Random.Range(0, squareRowCnt)],locT.position.z),
                squarePrefab[rndSquares].transform.rotation);
            }
            

            Debug.Log("Spawned.!!!!!!!!!");
            Debug.Log("Count: " + SquareContainerCode.squareCnt);
        }
    }
}   
