using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinBehaviour : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject playerPosition;
    float dist;
    [SerializeField] float coinSpeed;
    [SerializeField] int pointsForCoin;
    public Text textOfPoint;
    [SerializeField] float speedToPlayer;
    [HideInInspector] public static float rayDistance = 2.06f;

    private void Update()
    {
        if (GameObject.FindWithTag("Player") != null)
        {
            if ((dist = (Vector2.Distance(gameObject.transform.position, GameObject.FindWithTag("Player").transform.position))) <= rayDistance)
            {
                gameObject.transform.position = Vector2.Lerp(gameObject.transform.position, GameObject.FindWithTag("Player").transform.position , speedToPlayer * Time.deltaTime);
            }
        }
            
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(-coinSpeed , 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            PointsManager.points += pointsForCoin;
            textOfPoint.GetComponent<PointsManager>().pointsText.text = PointsManager.points.ToString();
            Destroy(gameObject);
            
        }    
        else if (collision.tag == "DestroyingWall")
        {
            Destroy(gameObject);
        }
        
    }
}
