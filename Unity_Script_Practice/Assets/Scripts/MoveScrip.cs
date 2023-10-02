using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    private CameraScript caScript;

    float hAxis;
    float vAxis;

    bool jDown;
    private bool isJump = false;

    public float mNum;

    public float moveSpeed;
    public float jumpForce;
    public float rotateSpeed;

    private Vector3 nomalMoveVec;
    private Vector3 topViewMoveVec;

    private Animator anim;
    private Rigidbody rigid;

    // 마우스 회전
    float xRotation = 0f;
    float yRotation;
    public float mouseSensitivity;

    public bool isCameraFixed = true;

    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        rigid = GetComponentInChildren<Rigidbody>();

        caScript = GameObject.Find("Manager").GetComponent<CameraScript>();
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

        if(caScript.caNum == 1)
        {
            rotateSpeed = 150f;
        }
    }

    private void GetInput()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
        jDown = Input.GetButtonDown("Jump");


        Vector3 vCam = caScript.currentCamera.transform.forward;
        Vector3 hCam = caScript.currentCamera.transform.right;

        vCam.y = 0f;
        hCam.y = 0f;

        vCam.Normalize();
        hCam.Normalize();

        nomalMoveVec = (vCam * vAxis + hCam * hAxis).normalized;
        topViewMoveVec = new Vector3(hAxis, 0, vAxis).normalized;

        xRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        yRotation += Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
    }

    private void Move()
    {
        if (caScript.caNum != 2)
        {
            transform.position += nomalMoveVec * moveSpeed * Time.deltaTime;
            anim.SetBool("isWalk", nomalMoveVec != Vector3.zero);
        }
        else
        {
            transform.position += topViewMoveVec * moveSpeed * Time.deltaTime;
            anim.SetBool("isWalk", topViewMoveVec != Vector3.zero);
        }

    }

    private void Rotate()
    {
        if (nomalMoveVec != Vector3.zero && vAxis >= 0)
        {
            Quaternion moveRotate = Quaternion.LookRotation(nomalMoveVec, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, moveRotate, rotateSpeed * Time.deltaTime);
        }
        if (caScript.caNum == 2)
        {
            if (topViewMoveVec != Vector3.zero)
            {
                Quaternion moveRotate = Quaternion.LookRotation(topViewMoveVec);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, moveRotate, rotateSpeed * Time.deltaTime);
            }
        }
    }

    private void MouseRotate()
    {
        if(caScript.caNum == 2) { return; }

        Quaternion mouseYRotate = Quaternion.Euler(0f, yRotation, 0f);
        transform.rotation = Quaternion.Lerp(transform.rotation, mouseYRotate, rotateSpeed * Time.deltaTime);
    }

    void CameraMove()
    {
        if (caScript.caNum == 0)
        {
            caScript.mCamera.transform.position = transform.position + transform.rotation * caScript.mainOffset;

            caScript.mCamera.transform.LookAt(transform);
            Vector3 curAngles = caScript.mCamera.transform.rotation.eulerAngles;
            caScript.mCamera.transform.rotation = Quaternion.Euler(20, curAngles.y, curAngles.z);
        }
        else if (caScript.caNum == 1)
        {
            // Move the camera to the player's position
            caScript.mCamera.transform.position = transform.position + transform.rotation * caScript.firstOffset;

            // Set the camera's rotation to match the player's rotation
            Vector3 playerRotation = transform.eulerAngles;
            caScript.mCamera.transform.rotation = Quaternion.Euler(playerRotation.x, playerRotation.y, playerRotation.z);
        }
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