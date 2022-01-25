using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dinosaur : MonoBehaviour
{
    Rigidbody2D rb;
    public float jump;
    bool isJumping;
    public GameManager GM;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)&&!isJumping){
            rb.velocity=new Vector2(0,jump);
            isJumping=true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        isJumping=false;

        if(other.gameObject.tag=="Cactus"){
            GM.GameOver();
        }
    }
}
