﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour {
    
    private CharacterController controller;
    private Vector3 moveVector;

    private float speed = 7.0f;
    private float verticalVelocity = 0.0f;
    private float gravity = 12.0f;
    private float animationDuration = 3.0f;

    private bool isDead = false;

	// Use this for initialization
	void Start () {
        controller = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {

        if (isDead)
            return;

        if(Time.time < animationDuration)
        {
            controller.Move(Vector3.forward * speed * Time.deltaTime);
            return;
        }

        moveVector = Vector3.zero;

        if(controller.isGrounded)
        {
            verticalVelocity = -0.5f;
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }

        //x
        moveVector.x = Input.GetAxisRaw("Horizontal")*speed;
        //y
        moveVector.y = verticalVelocity;
        //z
        moveVector.z = speed;

        controller.Move(moveVector * Time.deltaTime);
	}

    public void SetSpeed(float modifier)
    {
        speed = 5.0f + modifier;
    }

    //Called everytime capsule hits something
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.point.z > transform.position.z + controller.radius)
            Death();
    }

    private void Death()
    {
        isDead = true;
        GetComponent<Score>().OnDeath();
    }

}