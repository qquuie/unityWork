using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDomines : MonoBehaviour
{
	public GameObject dominePrefab;
	public GameObject domineEnd;
	public int numCenterDom = 9;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 dir = domineEnd.transform.position - transform.position;
        Debug.Log(dir);
        float offset = dir.magnitude / (numCenterDom + 1);
        dir.Normalize();

        for (int i = 1; i <= numCenterDom; i++)
        {
            //Debug.Log(transform.position + (dir * offset * i));
            GameObject newDom = (GameObject)Instantiate(dominePrefab);
            newDom.transform.position = transform.position + (dir * offset * i);
            newDom.transform.rotation = transform.rotation;
            //Debug.Log(newDom);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
