using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floorManager : MonoBehaviour
{
    public GameObject[] FloorType;
    int last=0;

    // Start is called before the first frame update

    public void SpawnFloor(){ 
        int r=Random.Range(0,FloorType.Length);
        if(r!=0){
            last=0;
        }
        else{
            last++;
        }        
        if(last>2){
            r=1;
            last=0;
        }
        GameObject floor= Instantiate(FloorType[r],transform);
        floor.transform.position=new Vector3(Random.Range(-3.8f,3.9f),-6,0);
    }
}
