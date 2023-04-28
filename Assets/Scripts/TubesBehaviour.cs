using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubesBehaviour : MonoBehaviour
{
    public bool isMoving;
    public float tubeSpeed;
    public GameObject tubeObject;
    public int direction = -1;

    private void Update()
    {
        if (tubeObject != null)
        {
            if (isMoving)
            {
                tubeObject.transform.Translate(new Vector2(direction, 0) * Time.deltaTime * tubeSpeed);     
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "DestroyingWall")
        {
            
            Destroy(this.gameObject);
        }
    }
}
