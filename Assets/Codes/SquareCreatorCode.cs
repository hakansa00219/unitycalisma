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

    void Start()
    {
        squareColCnt = xArr.Length;
        squareRowCnt = yArr.Length;
        
        locT = square.GetComponent<Transform>();

        /*Instantiate blocks*/
        for (int y = 0; y < squareRowCnt; ++y)
        {
            for (int x = 0; x < squareColCnt; ++x)
            {
                Instantiate(squarePrefab[Random.Range(0, squarePrefab.Length)], new Vector3(xArr[x], yArr[y], locT.position.z), Quaternion.identity);
            }
        }
    }

    void Update()
    {
    }
}
