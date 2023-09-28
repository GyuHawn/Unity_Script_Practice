using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObj : MonoBehaviour
{
    public GameObject sobj;
    public GameObject cobj;

    public void CreateSphere()
    {
        if (cobj != null && cobj.activeSelf)
        {
            cobj.SetActive(false);
        }

        sobj.SetActive(!sobj.activeSelf);
    }

    public void CreateCube()
    {
        if (sobj != null && sobj.activeSelf)
        {
            sobj.SetActive(false);
        }

        cobj.SetActive(!cobj.activeSelf);
    }
}
