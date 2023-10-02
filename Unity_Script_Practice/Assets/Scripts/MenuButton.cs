using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MenuButton : MonoBehaviour
{
    private MoveScript mScript;
    private ClickScript cScript;
    private PotalScript pScript;
    private CameraScript caScript;
    private UIScript uScript;

    public GameObject menuTab;
    public GameObject moveTab;
    public GameObject clickTab;
    public GameObject cameraTab;
    public GameObject uiTab;
    public GameObject objTab;
    public GameObject potalTab;

    public GameObject explanation;

    public GameObject[] allTabs;

    void Start()
    {
        mScript = GameObject.Find("Player").GetComponent<MoveScript>();
        cScript = GameObject.Find("Manager").GetComponent<ClickScript>();
        pScript = GameObject.Find("Manager").GetComponent<PotalScript>();
        caScript = GameObject.Find("Manager").GetComponent<CameraScript>();
        uScript = GameObject.Find("Manager").GetComponent<UIScript>();

        allTabs = new GameObject[] { moveTab, clickTab, cameraTab, uiTab, objTab, potalTab };
    }

    public void ToggleSingleTab(GameObject target)
    {
        foreach (var tab in allTabs)
        {
            if (tab != null)
            {
                tab.SetActive(tab == target && !tab.activeSelf);
            }
        }
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
        ToggleSingleTab(moveTab);
    }

    public void ClickBt()
    {
        ToggleSingleTab(clickTab);
    }

    public void CameraBt()
    {
        ToggleSingleTab(cameraTab);
    }

    public void UIBt()
    {
        ToggleSingleTab(uiTab);
    }

    public void ObjectBt()
    {
        ToggleSingleTab(objTab);
    }

    public void PotalBt()
    {
        ToggleSingleTab(potalTab);
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

    public void DisBt()
    {
        pScript.pNum = 2;
    }

    //Camera ---------------------------------

    public void FristBt()
    {
        caScript.caNum = 1;
    }
    public void ThirdBt()
    {
        caScript.caNum = 0;
    }

    public void TopBt()
    {
        caScript.caNum = 2;
    }


    //UI ---------------------------------

    public void InputBt()
    {
       uScript.uNum = 1;
    }

    public void CountBt()
    {
        uScript.uNum = 2;
    }
    public void TimeBt()
    {
        uScript.uNum = 3;
    }

    public void MapBt()
    {
        uScript.uNum = 4;
    }

}