using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCollisionEvent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        print("Collision Enter!");
    }

    //void OnCollisionStay(Collision collision)
    //{
    //    print("Collision Stay");
    //}

    void OnTriggerEnter(Collider collider)
    {
        print("On Trigger Enter!");
    }
}
