using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    float hAxis;
    float vAxis;

    bool jDown;
    private bool isJump = false;

    public GameObject mCamera;
    public Vector3 offset;

    public float mNum;

    public float moveSpeed = 5f;
    public float jumpForce = 6f;
    public float rotateSpeed = 200f;

    private Vector3 moveDirection;

    private Animator anim;
    private Rigidbody rigid;

    // 마우스 회전
    float yRotation;
    public float mouseSensitivity = 700f;

    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        rigid = GetComponentInChildren<Rigidbody>();
    }

    void Update()
    {
        GetInput();
        CameraMove();

        if (mNum >= 1)
        {
            Move();

            if (mNum >= 2)
            {
                Jump();

                if (mNum == 3)
                {
                    Rotate();
                }
                else if (mNum == 3.5)
                {
                    MouseRotate();
                }
            }
        }

    }

    private void GetInput()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
        jDown = Input.GetButtonDown("Jump");


        Vector3 camForward = Camera.main.transform.forward;
        Vector3 camRight = Camera.main.transform.right;

        camForward.y = 0f;
        camRight.y = 0f;

        camForward.Normalize();
        camRight.Normalize();

        moveDirection = (camForward * vAxis + camRight * hAxis).normalized;

        yRotation += Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
    }

    private void Move()
    {
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        anim.SetBool("isWalk", moveDirection != Vector3.zero);

    }

    private void Rotate()
    {
        if (moveDirection != Vector3.zero && vAxis >= 0)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotateSpeed * Time.deltaTime);
        }
    }

    private void MouseRotate()
    {
        //마우스 회전
        Quaternion yQuaternion = Quaternion.Euler(0f, yRotation, 0f);
        transform.rotation = Quaternion.Lerp(transform.rotation, yQuaternion, rotateSpeed * Time.deltaTime);
    }

    void CameraMove()
    {
        mCamera.transform.position = transform.position + transform.rotation * offset;

        mCamera.transform.LookAt(transform);

        Vector3 currentAngles = mCamera.transform.rotation.eulerAngles;

        mCamera.transform.rotation = Quaternion.Euler(20, currentAngles.y, currentAngles.z);
    }

    void Jump()
    {
        if (jDown && !isJump)
        {
            rigid.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isJump = true;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Map")
        {
            isJump = false;
        }
    }
}