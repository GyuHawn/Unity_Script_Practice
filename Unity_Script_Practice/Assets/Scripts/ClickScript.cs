using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickScript : MonoBehaviour
{
    private MoveScript moveScript;
    // 현재 선택한 버튼
    public float cNum;

    // 마우스 둘러보기 관련 변수
    public float speed;

    // 오브젝트 잡기 관련 변수
    private bool ObjCarrying = false;
    private GameObject CarriedObj;
    private Vector3 lastMousePos;

    // 웹사이트 관련 변수
    public GameObject google;

    void Start()
    {
        moveScript = GameObject.Find("Player").GetComponent<MoveScript>();

        speed = 1.0f;
    }

    void Update()
    {
        if (cNum == 1)
        {
            viewRotate();
        }
        else if (cNum == 2)
        {
            objCatch();
        }
        else if (cNum == 3)
        {
            webOpen();
        }
    }

    private void viewRotate()
    {
        if (Input.GetMouseButton(1))
        {
            moveScript.isCameraFixed = false;

            float mouseX = Input.GetAxis("Mouse X") * speed;
            float mouseY = Input.GetAxis("Mouse Y") * speed;

            Camera.main.transform.Rotate(Vector3.up, mouseX, Space.World);

            Camera.main.transform.Rotate(Vector3.right, -mouseY, Space.Self);
        }
        else
        {
            moveScript.isCameraFixed = true;
        }
    }

    private void objCatch()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            int layerMask = ~(1 << LayerMask.NameToLayer("Wall"));

            if (!ObjCarrying)
            {
                if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
                {
                    if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Obj"))
                    {
                        ObjCarrying = true;
                        CarriedObj = hit.transform.gameObject;
                        CarriedObj.GetComponent<Rigidbody>().isKinematic = true;
                        lastMousePos = Input.mousePosition;
                    }
                }
            }
            else
            {
                ObjCarrying = false;
                CarriedObj.GetComponent<Rigidbody>().isKinematic = false;
                CarriedObj = null;
            }
        }

        if (ObjCarrying)
        {
            Vector3 mouseMovePos = Input.mousePosition - lastMousePos;
            Vector3 xyMoveObjPos =
                Camera.main.transform.right * mouseMovePos.x +
                Camera.main.transform.up * mouseMovePos.y;

            float objMoveDistance =
                xyMoveObjPos.magnitude *
                Vector3.Distance(Camera.main.transform.position, CarriedObj.transform.position) / 600f;

            xyMoveObjPos.Normalize();
            xyMoveObjPos *= objMoveDistance;

            float mouseScrollMove = Input.GetAxis("Mouse ScrollWheel");

            float mouseScrollSpd = 5f;

            Vector3 verticalMove = Vector3.forward * mouseScrollMove * mouseScrollSpd;

            CarriedObj.transform.position += xyMoveObjPos + verticalMove;

            lastMousePos = Input.mousePosition;
        }
    }

    private void webOpen()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject == google)
                {
                    Application.OpenURL("https://www.google.com");
                }
            }
        }
    }
}