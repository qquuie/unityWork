using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    public float movespeed;
    GameObject currentFloor;
    public GameObject HpBar;
    public Text scoreText;
    public GameObject replayBtn;

    public int Hp;
    int score;
    float scoreTime;
    // Start is called before the first frame update
    void Start()
    {
        Hp=10;
        score=0;
        scoreTime=0f;
    }

    // Update is called once per frame
    void Update()
    {
        // transform.Translate(0,movespeed*Time.deltaTime,0);
        //Y值+0.01
        //避免每個電腦執行速度不一樣，導致一秒鐘跑出的結果不同
        if(Input.GetKey(KeyCode.D)){
            transform.Translate(movespeed*Time.deltaTime,0,0);
            GetComponent<SpriteRenderer>().flipX=false;
            GetComponent<Animator>().SetBool("run",true);
        }
        else if(Input.GetKey(KeyCode.A)){
            transform.Translate(-movespeed*Time.deltaTime,0,0);
            GetComponent<SpriteRenderer>().flipX=true;
            GetComponent<Animator>().SetBool("run",true);
        }else{
            GetComponent<Animator>().SetBool("run",false);
        }
        UpdateScore();
    }
    
    private void OnCollisionEnter2D(Collision2D other) {
        //藉由法向量判斷
        if(other.gameObject.tag=="Normal"){
            if(other.contacts[0].normal==new Vector2(0f,1f)){
                currentFloor=other.gameObject;
                modifyHP(1);
                other.gameObject.GetComponent<AudioSource>().Play();
            }
        }
        if(other.gameObject.tag=="Nails"){
            if(other.contacts[0].normal==new Vector2(0f,1f)){
                currentFloor=other.gameObject;
                GetComponent<Animator>().SetTrigger("hurt");
                modifyHP(-3);
                other.gameObject.GetComponent<AudioSource>().Play();                
            }
        }
        if(other.gameObject.tag=="Ceiling"){
            currentFloor.GetComponent<BoxCollider2D>().enabled=false;
            GetComponent<Animator>().SetTrigger("hurt");
            modifyHP(-3);
            other.gameObject.GetComponent<AudioSource>().Play();                
        }
        // Debug.Log(Hp);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag=="DeathLine"){
            die();
        }
    }

    void modifyHP(int num){
        Hp+=num;
        if(Hp>10){
            Hp=10;
        }
        else if(Hp<=0){
            Hp=0;
            die();
        }
        updateHP();
    }

    void updateHP(){
        for(int i=0;i<HpBar.transform.childCount;i++){
            if(Hp>i){
                HpBar.transform.GetChild(i).gameObject.SetActive(true);
            }
            if(Hp<=i){
                HpBar.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }

    void UpdateScore(){
        scoreTime+=Time.deltaTime;
        if(scoreTime>2f){
            score++;
            scoreTime=0;
            scoreText.text="地下"+score.ToString()+"層";
        }
    }

    void die(){
        GetComponent<AudioSource>().Play();
        Time.timeScale=0;
        replayBtn.SetActive(true);
    }

    public void replay(){
        Time.timeScale=1;
        SceneManager.LoadScene("SampleScene");
    }
}
