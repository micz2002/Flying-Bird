using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
   public  Renderer _offset;
    public float scrollingSpeed;

    void Start()
    {
        _offset = gameObject.transform.GetComponent<Renderer>();   
    }

    
    void Update()
    {
        _offset.material.mainTextureOffset = new Vector2(scrollingSpeed * Time.time, 0);
    }
}
