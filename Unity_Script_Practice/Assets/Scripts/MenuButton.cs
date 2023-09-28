using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MenuButton : MonoBehaviour
{
    private MoveScript mScript;

    public GameObject menuTab;
    public GameObject moveTab;
    public GameObject clickTab;
    public GameObject objTab;

    public GameObject explanation;

    void Start()
    {
        mScript = GameObject.Find("Player").GetComponent<MoveScript>();
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
        if (clickTab != null && clickTab.activeSelf || objTab != null && objTab.activeSelf)
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
        if (moveTab != null && moveTab.activeSelf || objTab != null && objTab.activeSelf)
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
        if (moveTab != null && moveTab.activeSelf || clickTab != null && clickTab.activeSelf)
        {
            moveTab.SetActive(false);
            clickTab.SetActive(false);
        }

        if (objTab != null)
        {
            objTab.SetActive(!objTab.activeSelf);
        }
    }

    public void ExBt()
    {
        if (explanation != null)
        {
            explanation.SetActive(!explanation.activeSelf);
        }
    }


    //---------------------------------
    public void MoveBtStart()
    {
        mScript.mNum = 1;
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
        mScript.mNum = 4;
    }

}
