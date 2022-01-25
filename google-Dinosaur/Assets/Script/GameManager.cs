using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject cactus;
    public GameObject cactusSpawnPosition;
    public float spawnTime;
    float timer;
    public GameObject GameOverScene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer+=Time.deltaTime;
        if(timer >=spawnTime){
            Instantiate(cactus,cactusSpawnPosition.transform);
            timer=0;
        }
    }

    public void GameOver(){
        Time.timeScale=0;
        GameOverScene.SetActive(true);
    }

    public void Restart(){
        Time.timeScale=1;
        SceneManager.LoadScene("SampleScene");
    }
}
