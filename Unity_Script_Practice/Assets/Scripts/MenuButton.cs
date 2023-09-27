using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MenuButton : MonoBehaviour
{
    public GameObject menuTab;
    public GameObject moveTab;

    public GameObject explanation;


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

}
