using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private MoveScript mScript;

    public float caNum;

    public GameObject mCamera;
    public GameObject topCamera;
    public GameObject currentCamera;
    public Vector3 mainOffset;
    public Vector3 firstOffset;
    public Vector3 topOffset;

    private void Start()
    {
        currentCamera = mCamera;
    }

    void Update()
    {
        if(caNum != 2)
        {
            currentCamera = mCamera;
            mCamera.SetActive(true);
            topCamera.SetActive(false);
        }
        else
        {
            currentCamera = topCamera;
            mCamera.SetActive(false);
            topCamera.SetActive(true);
        }
    }
}
