using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine.Utility;
using UnityEngine.Animations.Rigging;
using Unity.VisualScripting;
using System;

//마우스 이동 스크립트
public class TestScripts : MonoBehaviour
{
    Vector3 Pos;
    Vector3 dir;
    Quaternion lookTarget;
    public float moveSpeed = 5f;
    bool isMoveable = false;

    private void Start()
    {
    }
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            OnMouseClick();
        }
        if (isMoveable)
        {
            Move();
        }
    }

    void Move()
    {
        transform.position += dir.normalized * Time.deltaTime * moveSpeed;
        transform.rotation = Quaternion.Lerp(transform.rotation, lookTarget, 0.25f);
        float dt = Vector3.Distance(transform.position, Pos);
        if (dt <= 1f)
        {
            isMoveable = false;
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Wall")
        {
            isMoveable = false ;
        }
    }
    void OnMouseClick()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100f))
            {
                Debug.DrawRay(Camera.main.transform.position, ray.direction * 100.0f, Color.yellow, 1.0f);
                Pos = new Vector3(hit.point.x, transform.position.y, hit.point.z);
                dir = Pos - transform.position;
                lookTarget = Quaternion.LookRotation(dir);
                isMoveable = true;
            }
        }
    }
}
