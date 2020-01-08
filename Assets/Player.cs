using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    CharacterController characterController;

    public float gravity = 20f;
    public float speed = 6f;
    public float jumpSpeed = 8f;

    private Vector3 moveDir = Vector3.zero;

    void Start()
    {
        characterController = gameObject.GetComponent<CharacterController>();
    }

    void Update()
    {
        
        if (characterController.isGrounded)
        {
            moveDir = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDir *= speed;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                moveDir.y = jumpSpeed;
            }
        }

        else if (characterController.isGrounded == false)
        {
            moveDir.x = Input.GetAxis("Horizontal") * speed;
            moveDir.z = Input.GetAxis("Vertical") * speed;
        }

        moveDir.y -= gravity * Time.deltaTime;
        characterController.Move(moveDir * Time.deltaTime);
    }
}
