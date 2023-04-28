using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverObject;
    [SerializeField] PointsManager pointsManagerScript;

    private void Start()
    {
        
    }
    private void Update()
    {
        if(GameObject.FindGameObjectWithTag("Player") == null)
        {
            gameOverObject.SetActive(true);
            pointsManagerScript.GetComponent<PointsManager>().enabled = false;
        }
    }
}
