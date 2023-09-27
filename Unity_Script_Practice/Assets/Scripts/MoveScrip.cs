using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    public GameObject mCamera;
    public Vector3 offset;

    public int mNum;

    public float moveSpeed = 5f;
    public float rotateSpeed = 200f;

    private Vector3 moveDirection;

    void Update()
    {
        ProcessInputs();
        CameraMove();

        if (mNum > 0)
        {
            Move();
            if (mNum > 1)
            {
                Rotate();
                if (mNum > 2)
                {

                }
            }
        }
    }

    private void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        Vector3 camForward = Camera.main.transform.forward;
        Vector3 camRight = Camera.main.transform.right;

        camForward.y = 0f;
        camRight.y = 0f;

        camForward.Normalize();
        camRight.Normalize();

        moveDirection = (camForward * moveZ + camRight * moveX).normalized;
    }

    private void Move()
    {
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

    private void Rotate()
    {
        if (moveDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotateSpeed * Time.deltaTime);
        }
    }

    void CameraMove()
    {
        mCamera.transform.position = transform.position + transform.rotation * offset;

        mCamera.transform.LookAt(transform);

        Vector3 currentAngles = mCamera.transform.rotation.eulerAngles;

        mCamera.transform.rotation = Quaternion.Euler(20, currentAngles.y, currentAngles.z);
    }
}