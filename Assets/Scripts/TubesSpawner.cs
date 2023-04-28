using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class TubesSpawner : MonoBehaviour
{ 
    public GameObject tubeObject;
    int randomTube;
    float randomDelay;
   /*uint nie przechowuje liczb ujemnych*/
    int topTubesCounterInARow;
    int bottomTubesCounterInARow;
    public int topTubesInARow;
    public int bottomTubesInARow;

    const int sizeOfArrayOfTopT = 3;
    float[] hightOfTopTubes = new float [sizeOfArrayOfTopT] { 5.85f, 7.15f, 5.13f };

    const int sizeOfArrayOfBottomT = 2;
    float[] hightOfBottomTubes = new float[sizeOfArrayOfBottomT] { -5.79f, -5.12f };

    [SerializeField] PointsManager pointsManagerScript;


    void Start()
    {
        randomDelay = Random.Range(1, 2);
        pointsManagerScript.GetComponent<PointsManager>().enabled = true;
    }
    void Update()
    {
        
        randomDelay -= Time.deltaTime;
        if (randomDelay <= 0)
        {
            randomTube = Random.Range(1,3);

               if (randomTube == 1 )
            {
                Instantiate(tubeObject, new Vector2(13f, hightOfTopTubes[Random.Range(0, sizeOfArrayOfTopT)]), Quaternion.identity);
                RandomDelay();
                tubeObject.transform.tag = "Tube";
                topTubesCounterInARow++;
                if (topTubesCounterInARow > topTubesInARow)
                { topTubesCounterInARow = topTubesInARow; }
                bottomTubesCounterInARow--;
                if(bottomTubesCounterInARow < 0)
                {
                    bottomTubesCounterInARow = 0;
                }
                
               // Debug.Log(topTubesCounterInARow); Debug.Log(bottomTubesCounterInARow);

            }
            else if (randomTube == 2)
            {
                GameObject reverseTube = Instantiate(tubeObject, new Vector2(13f, hightOfBottomTubes[Random.Range(0, sizeOfArrayOfBottomT)]), Quaternion.Euler(new Vector3(0, 0, 180)));
                reverseTube.GetComponent<TubesBehaviour>().direction = 1;
                reverseTube.transform.tag = "Tube";
                RandomDelay();
                bottomTubesCounterInARow++;
                if(bottomTubesCounterInARow > bottomTubesInARow)
                { bottomTubesCounterInARow = bottomTubesInARow; }
                topTubesCounterInARow--;
                if(topTubesCounterInARow < 0)
                { topTubesCounterInARow = 0; }
                
               // Debug.Log(topTubesCounterInARow); Debug.Log(bottomTubesCounterInARow);
            }
            if (topTubesCounterInARow >= topTubesInARow)
            {
                GameObject reverseTube = Instantiate(tubeObject, new Vector2(16f, hightOfBottomTubes[Random.Range(0, sizeOfArrayOfBottomT)]), Quaternion.Euler(new Vector3(0, 0, 180)));
                reverseTube.GetComponent<TubesBehaviour>().direction = 1;
                reverseTube.transform.tag = "Tube";
                RandomDelay();
                topTubesCounterInARow = 0;
                 
               // Debug.Log(topTubesCounterInARow); Debug.Log(bottomTubesCounterInARow);
            }
             else if(bottomTubesCounterInARow >= bottomTubesInARow)
            {
                Instantiate(tubeObject, new Vector2(16f, hightOfTopTubes[Random.Range(0, sizeOfArrayOfTopT)]), Quaternion.identity);
                tubeObject.transform.tag = "Tube";
                RandomDelay();
                bottomTubesCounterInARow = 0;              
                
                //Debug.Log(topTubesCounterInARow); Debug.Log(bottomTubesCounterInARow);
            }
            Debug.Log("random delay = " + randomDelay);
            
        }
    }
    void RandomDelay()
    {
        if (PointsManager.points <= 50)
        {
            randomDelay = Random.Range(1, 2);
        }
        else if (PointsManager.points <= 100)
        {
            randomDelay = Random.Range(1 * 0.7f, 2 * 0.7f);
        }
        else if (PointsManager.points <= 150)
        {
            CoinBehaviour.rayDistance = 3.06f;
            randomDelay = Random.Range(1 * 0.5f, 2 * 0.5f);
        }
        else
        {
            randomDelay = Random.Range(1 * 0.35f, 2 * 0.35f);
        }    
    }

}
   

