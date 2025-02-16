using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Animator anim;
    Transform tr;
    Rigidbody rb;
    Vector3 moveDir;

    public float walkSpeed = 10;
    float runSpeed;
    float currentSpeed;
    bool isMoveable = false;
    bool isRuning = false;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        currentSpeed = walkSpeed;        
    }

    void Update()
    {
        if (moveDir != Vector3.zero && isMoveable == true)//키 입력이 있다면
        {
            transform.rotation = Quaternion.LookRotation(moveDir);            
            transform.position += moveDir.normalized * Time.deltaTime * currentSpeed;
            //transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        }
    }
    
    void OnMove(InputValue val)
    {
        isMoveable = true;
        Vector2 dir = val.Get<Vector2>();
        moveDir = new Vector3(dir.x, 0, dir.y);
        //anim.SetFloat("MoveFloat", dir.magnitude);
    }

    void OnRun(InputValue val)
    {
        isRuning = !isRuning;
        runSpeed = walkSpeed * 1.5f;
        Debug.Log(runSpeed);
        currentSpeed = isRuning ? runSpeed : walkSpeed;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Wall")
        {
            isMoveable = false;
        }
    }
}
