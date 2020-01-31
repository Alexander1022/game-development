using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{

    public float speed = 5.0F;
    public float jumpSpeed = 6.0F;
    public float gravity = 15.0F;
    public float shiftSpeed = 12.0F;
    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       CharacterController controller = GetComponent<CharacterController>();

       if(controller.isGrounded)
       {
           moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
           moveDirection = transform.TransformDirection(moveDirection);
           moveDirection = speed * moveDirection;
           if(Input.GetButton("Jump"))
           {
               moveDirection.y = jumpSpeed;
           }
          /*if(Input.GetButton(KeyCode.LeftShift))
           {
               speed  = shiftSpeed;
           }*/
       }
       moveDirection.y -= gravity * Time.deltaTime;
       controller.Move(moveDirection * Time.deltaTime);
       
    }
}
