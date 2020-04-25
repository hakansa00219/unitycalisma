using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareCreatorCode : MonoBehaviour
{
    public GameObject square;

    public GameObject[] squarePrefab;

    private Transform locT;

    private float[] xArr = { -5, -3.5f, -2, -0.5f, 1, 2.5f, 4, 5.5f };
    private float[] yArr = { 0, -1.5f, -3, -4.5f, -6};
    private int squareColCnt;
    private int squareRowCnt;
    private int squarePrefabCnt;
    // Start is called before the first frame update
    void Start()
    {
        squareColCnt = xArr.Length;
        squareRowCnt = yArr.Length;
        
        locT = square.GetComponent<Transform>();

        for(int y = 0; y<squareRowCnt; ++y)
        for (int x = 0; x < squareColCnt; ++x)
            {
                Instantiate(squarePrefab[Random.Range(0, squarePrefab.Length)], new Vector3(xArr[x], yArr[y]+4, locT.position.z), Quaternion.identity);
            }

        //StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {
    }
    /*
    IEnumerator Spawn()
    {
        while (true)
        {

            //int x = Random.Range(0, 299);
            //float randX = Random.Range(-3f, 3f);

            int randx = Random.Range(0, 8);

            Instantiate(squarePrefab, new Vector3(xArr[randx], locT.position.y, locT.position.z), Quaternion.identity);

            //Debug.Log(mylist.Count + ". block created.");
            yield return new WaitForSeconds(1);
        }

    }*/
}
