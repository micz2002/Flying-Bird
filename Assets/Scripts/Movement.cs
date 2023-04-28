using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D body;
    public float powerOfJump;
    bool jump = false;

    //public const string LEFT = "left";
    //public const string RIGHT = "right";
    //string buttonPressed;

    
    void Start()
    {
        body = GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void Update()
    {       
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        }
    }
    private void FixedUpdate()
    {
        if (jump == true)
        {
            body.AddForce(new Vector2(0, powerOfJump), ForceMode2D.Force);
            jump = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "BottomDestroy")
        {
            {
                Destroy(gameObject);
            }
        }
        else if (collision.gameObject.tag == "Tube")
        {
            Destroy(gameObject);
        }
    }
}
