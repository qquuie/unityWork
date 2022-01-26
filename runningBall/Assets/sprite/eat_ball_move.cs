using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eat_ball_move : MonoBehaviour
{
    public int MoveSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * MoveSpeed * Time.deltaTime, Space.World);
    }
}
