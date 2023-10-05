using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private MoveScript mScript;

    // ���� ������ ��ư 
    public float caNum;

    // ī�޶� ���� ����
    public GameObject mCamera;
    public GameObject topBCamera;
    public GameObject topWCamera;
    public GameObject currentCamera;

    public Vector3 mainOffset;
    public Vector3 firstOffset;
    public Vector3 topOffset;

    private void Start()
    {
        currentCamera = mCamera;
        mScript = GameObject.Find("Player").GetComponent<MoveScript>();
    }

    void Update()
    {
        if (caNum != 2)
        {
            currentCamera = mCamera;
            mCamera.SetActive(true);
            topBCamera.SetActive(false);
            topWCamera.SetActive(false);
        }
        else
        {
            if (!mScript.moveMap)
            {
                currentCamera = topBCamera;
                mCamera.SetActive(false);
                topBCamera.SetActive(true);
                topWCamera.SetActive(false);
            }
            else if (mScript.moveMap)
            {
                currentCamera = topWCamera;
                mCamera.SetActive(false);
                topBCamera.SetActive(false);
                topWCamera.SetActive(true);
            }
        }
    }
}
