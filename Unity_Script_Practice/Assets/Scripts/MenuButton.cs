using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MenuButton : MonoBehaviour
{
    private MoveScript mScript;
    private ClickScript cScript;
    private PotalScript pScript;

    public GameObject menuTab;
    public GameObject moveTab;
    public GameObject clickTab;
    public GameObject objTab;
    public GameObject potalTab;

    public GameObject explanation;

    void Start()
    {
        mScript = GameObject.Find("Player").GetComponent<MoveScript>();
        cScript = GameObject.Find("Manager").GetComponent<ClickScript>();
        pScript = GameObject.Find("Manager").GetComponent<PotalScript>();
    }

    public void MenuBt()
    {
        if (menuTab != null)
        {
            menuTab.SetActive(!menuTab.activeSelf);
        }
    }
    public void MoveBt()
    {
        if (clickTab != null && clickTab.activeSelf || objTab != null && objTab.activeSelf || potalTab != null && potalTab.activeSelf)
        {
            clickTab.SetActive(false);
            objTab.SetActive(false);
        }

        if (moveTab != null)
        {
            moveTab.SetActive(!moveTab.activeSelf);
        }
    }

    public void ClickBt()
    {
        if (moveTab != null && moveTab.activeSelf || objTab != null && objTab.activeSelf || potalTab != null && potalTab.activeSelf)
        {
            moveTab.SetActive(false);
            objTab.SetActive(false);
        }

        if (clickTab != null)
        {
            clickTab.SetActive(!clickTab.activeSelf);
        }
    }

    public void ObjectBt()
    {
        if (moveTab != null && moveTab.activeSelf || clickTab != null && clickTab.activeSelf || potalTab != null && potalTab.activeSelf)
        {
            moveTab.SetActive(false);
            clickTab.SetActive(false);
        }

        if (objTab != null)
        {
            objTab.SetActive(!objTab.activeSelf);
        }
    }

    public void PotalBt()
    {
        if (moveTab != null && moveTab.activeSelf || clickTab != null && clickTab.activeSelf || objTab != null && objTab.activeSelf)
        {
            moveTab.SetActive(false);
            clickTab.SetActive(false);
        }

        if (potalTab != null)
        {
            potalTab.SetActive(!potalTab.activeSelf);
        }
    }

    public void ExBt()
    {
        if (explanation != null)
        {
            explanation.SetActive(!explanation.activeSelf);
        }
    }


    //Move ---------------------------------
    public void MoveBtStart()
    {
        mScript.mNum = 1;
    }
    public void ClickMoveBtStart()
    {
        mScript.mNum = 1.5f;
    }
    public void JumpBtStart()
    {
        mScript.mNum = 2;
    }
    public void TurnBtStart()
    {
        mScript.mNum = 3;
    }
    public void MouseRoteStart()
    {
        mScript.mNum = 3.5f;
    }

    //Click ---------------------------------

    public void ViewRoteBt()
    {
        cScript.cNum = 1;
    }

    public void ObjCatchBt()
    {
        cScript.cNum = 2; 
    }
    public void WebOpenBt()
    {
        cScript.cNum = 3;
    }

    //Potal ---------------------------------

    public void ActBt()
    {
        pScript.pNum = 1;
    }

    public void DisBit()
    {
        pScript.pNum = 2;
    }
}
