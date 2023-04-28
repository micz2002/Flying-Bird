using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubesManager : MonoBehaviour
{
    public float tubeSpeed;
    public GameObject [] tubes;
    int x = 15;

    private void Update()
    {
        tubes = GameObject.FindGameObjectsWithTag("Tube");

        foreach(GameObject tube in tubes)
        {
            tube.GetComponent<TubesBehaviour>().tubeSpeed = tubeSpeed;

            if (PointsManager.points >= x)
            {
                tubeSpeed += 1;
                x += 15;
            }
        }
    }
}
