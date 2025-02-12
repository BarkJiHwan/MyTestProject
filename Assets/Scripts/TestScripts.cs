using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestScripts : MonoBehaviour
{
    Transform tr;
    Vector3 moveDir;

    void OnMove(InputValue val)
    {
        Vector2 dir = val.Get<Vector2>();
        moveDir = new Vector3(dir.x,0,dir.y);
    }
    void OnAttack()
    {
        Debug.Log("АјАн");
    }
    void Update()
    {
        if (moveDir != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveDir);
            transform.Translate(Vector3.forward * Time.deltaTime * 4.0f);
        }
    }
}
