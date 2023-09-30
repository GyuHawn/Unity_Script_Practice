using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickScript : MonoBehaviour
{
    public float cNum;

    public GameObject google;

    void Update()
    {
        if(cNum == 1)
        {

        }

        if (cNum == 2)
        {

        }

        if (cNum == 3)
        {
            webOpen();
        }
    }

    private void viewRotate()
    {

    }

    private void objCatch()
    {

    }

    private void webOpen()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // Check if the clicked object is "google"
                if (hit.transform.gameObject == google)
                {
                    // Open google.com in the default web browser
                    Application.OpenURL("https://www.google.com");
                }
            }
        }
    }
}
