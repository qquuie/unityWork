using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creat_ball : MonoBehaviour
{
    public Transform ball;
    public List<GameObject> prefabAnimal;
    public float timeGap=3;
    public float spawnDistance=10;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CreateAnimal());
    }

    // Update is called once per frame

    IEnumerator CreateAnimal(){
        while (true)
        {
            int i=Random.Range(0,prefabAnimal.Count);
            GameObject prefab=prefabAnimal[i];

            Vector3 pos=new Vector3(Random.Range(-5f,5f),1,spawnDistance);
            pos.z+=ball.position.z;

            GameObject animal=Instantiate(prefab,pos,Quaternion.identity);
            yield return new WaitForSeconds(timeGap);
        }
    }
}
