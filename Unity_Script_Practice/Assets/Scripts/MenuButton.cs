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
    private WorkTextScript wtScript;

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
        pScript = GameObject.Find("WPotal").GetComponent<PotalScript>();
        caScript = GameObject.Find("Manager").GetComponent<CameraScript>();
        uScript = GameObject.Find("Manager").GetComponent<UIScript>();
        wtScript = GameObject.Find("Manager").GetComponent<WorkTextScript>();

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
        wtScript.SetText(wtScript.mText);
    }
    public void JumpBtStart()
    {
        mScript.mNum = 2;
        wtScript.SetText(wtScript.jText);
    }
    public void TurnBtStart()
    {
        mScript.mNum = 3;
        wtScript.SetText(wtScript.tText);
    }
    public void MouseRoteStart()
    {
        mScript.mNum = 3.5f;
        wtScript.SetText(wtScript.mtText);
    }

    //Click ---------------------------------

    public void ViewRoteBt()
    {
        cScript.cNum = 1;
        wtScript.SetText(wtScript.mvText);
    }

    public void ObjCatchBt()
    {
        cScript.cNum = 2;
        wtScript.SetText(wtScript.cText);
    }
    public void WebOpenBt()
    {
        cScript.cNum = 3;
        wtScript.SetText(wtScript.wText);
    }

    //Potal ---------------------------------

    public void ActBt()
    {
        pScript.pNum = 1;
        wtScript.SetText(wtScript.acText);
    }

    public void DisBt()
    {
        pScript.pNum = 2;
        wtScript.SetText(wtScript.diText);
    }

    //Camera ---------------------------------

    public void FristBt()
    {
        caScript.caNum = 1;
        wtScript.SetText(wtScript.fiText);
    }
    public void ThirdBt()
    {
        caScript.caNum = 0;
        wtScript.SetText(wtScript.thText);
    }

    public void TopBt()
    {
        caScript.caNum = 2;
        wtScript.SetText(wtScript.topText);
    }


    //UI ---------------------------------

    public void InputBt()
    {
       uScript.uNum = 1;
       wtScript.SetText(wtScript.inText);
    }

    public void CountBt()
    {
        uScript.uNum = 2;
        wtScript.SetText(wtScript.countText);
    }
    public void TimeBt()
    {
        uScript.uNum = 3;
        wtScript.SetText(wtScript.ctText);
    }

}