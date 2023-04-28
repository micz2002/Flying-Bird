using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsSpawner : MonoBehaviour
{
    public float spawnDelay;
    float delay;
    float randomPositionY;
    public GameObject coin;
    private void Start()
    {
        delay = spawnDelay;
    }
    private void Update()
    {
        randomPositionY = Random.Range(-4.07f, 5.07f);
        delay -= Time.deltaTime;
        if(delay <= 0 )
        {
            Instantiate(coin, new Vector2(11, randomPositionY), Quaternion.identity);
                delay = spawnDelay;
        }
    }
}
