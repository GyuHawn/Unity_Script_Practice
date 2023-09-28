using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MenuButton : MonoBehaviour
{
    private MoveScript mScript;

    public GameObject menuTab;
    public GameObject moveTab;

    public GameObject explanation;

    private void Start()
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
    public void MoveuBt()
    {
        if (moveTab != null)
        {
            moveTab.SetActive(!moveTab.activeSelf);
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
