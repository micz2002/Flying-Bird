using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsManager : MonoBehaviour
{
    public Text pointsText;
    [HideInInspector] public static int points;
    float delay = 1;

    private void Start()
    {
        pointsText.text = "0";
        points = 0;     
    }
    void Update()
    {
        delay -= Time.deltaTime;
            if(delay <= 0)
        {
            points ++;
            pointsText.text = points.ToString();
            delay = 1;
        }
    }
}
