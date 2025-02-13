using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine.Utility;

public class TestScripts : MonoBehaviour
{
    Vector3 Pos;
    Vector3 dir;
    Quaternion lookTarget;

    public float moveSpeed = 5f;
    bool isMoveable = false;
    void Update()
    {
        if(Input.GetMouseButton(1))
        {
            RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100f))
            {
                Debug.DrawRay(Camera.main.transform.position, ray.direction * 100.0f, Color.yellow, 1.0f); 
                Pos = new Vector3(hit.point.x, transform.position.y, hit.point.z);
                Debug.Log(Pos);
                dir = Pos - transform.position;
                Debug.Log(dir);
                lookTarget = Quaternion.LookRotation(dir);
                isMoveable = true;
            }
        }
        Move();
        
    }

    void Move()
    {
        if(isMoveable == true)
        {
            transform.position += dir.normalized * Time.deltaTime * moveSpeed;
            transform.rotation = Quaternion.Lerp(transform.rotation, lookTarget, 0.25f);
            float dt = Vector3.Distance(transform.position, Pos);
            if (dt <= 1f)
            {
                 isMoveable = false;
            }
        }
    }

    //Transform tr;
    //Vector3 moveDir;

    //void OnMove(InputValue val)
    //{
    //    Vector2 dir = val.Get<Vector2>();
    //    moveDir = new Vector3(dir.x,0, dir.y);
    //}
    //void OnAttack()
    //{
    //    Debug.Log("АјАн");
    //}
    //void Update()
    //{
    //    if (moveDir != Vector3.zero)
    //    {
    //        transform.rotation = Quaternion.LookRotation(moveDir);
    //        transform.Translate(Vector3.forward * Time.deltaTime * 4.0f);
    //    }
    //}
}
