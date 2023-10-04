using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObj : MonoBehaviour
{
    private WorkTextScript wtScript;

    public GameObject sobj;
    public GameObject cobj;

    void Start()
    {
        wtScript = GameObject.Find("Manager").GetComponent<WorkTextScript>();
    }

    public void CreateSphere()
    {
        if (cobj != null && cobj.activeSelf)
        {
            cobj.SetActive(false);
        }

        sobj.SetActive(!sobj.activeSelf);
        wtScript.SetText(wtScript.sphereText);
    }

    public void CreateCube()
    {
        if (sobj != null && sobj.activeSelf)
        {
            sobj.SetActive(false);
        }

        cobj.SetActive(!cobj.activeSelf);
        wtScript.SetText(wtScript.cubeText);
    }
}
