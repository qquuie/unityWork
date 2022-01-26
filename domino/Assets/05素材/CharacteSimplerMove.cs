using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacteSimplerMove : MonoBehaviour
{
    CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector3 speed = new Vector3(0, 0, 0);
		
		if (controller.isGrounded)
		{
			if (Input.GetKey(KeyCode.A))
				speed.x = 5;
		}

        controller.SimpleMove(speed);
    }
}
