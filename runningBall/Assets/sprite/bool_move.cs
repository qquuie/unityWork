using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class bool_move : MonoBehaviour
{
    public int MoveSpeed = 5;
    public int turnSpeed = 3;
    AudioSource audioSource;
    public AudioClip diesound;
    public Text score_text;
    public Text GameOver;
    // public Text score_num;
    int score=0;
    bool lose=false;

    bool lose_speed=false;
    int secound=0;
    int wolve=1;
    

    // Start is called before the first frame update
    void Start()
    {
        audioSource=GetComponent<AudioSource>();
        score_text.text="";
        GameOver.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       if(!lose){
            transform.Translate(Vector3.forward * MoveSpeed * Time.deltaTime, Space.World);
             RL_move();
       }

        secound++;
        if(secound>1000*wolve){
            MoveSpeed++;
            wolve++;
        }

       if(lose_speed){
           MoveSpeed--;
           if(MoveSpeed<0){
               MoveSpeed=1;
           }
           lose_speed=false;
       }

    }

    void RL_move()
    {
        float x = Input.GetAxis("Horizontal");

        if (Mathf.Abs(x) > 0.5f)
        {
            transform.Rotate(0,x*Time.deltaTime*turnSpeed,0);
            transform.Translate(x * Time.deltaTime*MoveSpeed, 0, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("tree"))
        {
            lose=true;
            audioSource.clip=diesound;
            audioSource.Play();
            GameOver.gameObject.SetActive(true);
        }

        if (other.gameObject.layer == LayerMask.NameToLayer("ball"))
        {
            lose_speed=true;
            score+=10;
            score_text.text=score.ToString();
            Destroy(other.gameObject);
            audioSource.Play();
        }
    }
}
