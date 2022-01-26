using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushDominoes : MonoBehaviour
{
	public GameObject dominoeStart;
	public float      force = 4.0f;
	
	Rigidbody rb;
	
    // Start is called before the first frame update
    void Start()
    {
		rb = dominoeStart.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
		{
            Debug.Log(1);
			rb.AddForce(force, 0, 0, ForceMode.Impulse);
		}
    }
}
