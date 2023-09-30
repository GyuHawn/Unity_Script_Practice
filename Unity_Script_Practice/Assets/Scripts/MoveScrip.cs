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

    public float moveSpeed;
    public float jumpForce;
    public float rotateSpeed;

    private Vector3 moveVec;

    private Animator anim;
    private Rigidbody rigid;

    // 마우스 회전
    float yRotation;
    public float mouseSensitivity;

    public bool isCameraFixed = true;

    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        rigid = GetComponentInChildren<Rigidbody>();
    }
    void Start()
    {
        moveSpeed = 5f;
        jumpForce = 6f;
        rotateSpeed = 200f;

        mouseSensitivity = 700f;
    }

    void Update()
    {
        GetInput();

        if (isCameraFixed)
        {
            CameraMove();
        }

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


        Vector3 vCam = Camera.main.transform.forward;
        Vector3 hCam = Camera.main.transform.right;

        vCam.y = 0f;
        hCam.y = 0f;

        vCam.Normalize();
        hCam.Normalize();

        moveVec = (vCam * vAxis + hCam * hAxis).normalized;

        yRotation += Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
    }

    private void Move()
    {
        transform.position += moveVec * moveSpeed * Time.deltaTime;

        anim.SetBool("isWalk", moveVec != Vector3.zero);

    }

    private void Rotate()
    {
        if (moveVec != Vector3.zero && vAxis >= 0)
        {
            Quaternion moveRotate = Quaternion.LookRotation(moveVec, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, moveRotate, rotateSpeed * Time.deltaTime);
        }
    }

    private void MouseRotate()
    {
        //마우스 회전
        Quaternion mouseYRotate = Quaternion.Euler(0f, yRotation, 0f);
        transform.rotation = Quaternion.Lerp(transform.rotation, mouseYRotate, rotateSpeed * Time.deltaTime);
    }

    void CameraMove()
    {
        mCamera.transform.position = transform.position + transform.rotation * offset;

        mCamera.transform.LookAt(transform);

        Vector3 curAngles = mCamera.transform.rotation.eulerAngles;

        mCamera.transform.rotation = Quaternion.Euler(20, curAngles.y, curAngles.z);
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