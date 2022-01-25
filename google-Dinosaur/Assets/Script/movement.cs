﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float movemontSpeed;
    public float startPosition;
    public float endPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position=new Vector2(transform.position.x-movemontSpeed*Time.deltaTime,transform.position.y);
        if(transform.position.x<=endPosition){
            if(gameObject.tag=="Cactus"){
                Destroy(gameObject);
            }else{
                transform.position=new Vector2(startPosition,transform.position.y);
            }
        }
    }
}
