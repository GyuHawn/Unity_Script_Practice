using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkTextScript : MonoBehaviour
{
    public GameObject mText;
    public GameObject jText;
    public GameObject tText;
    public GameObject mtText;
    public GameObject mvText;
    public GameObject cText;
    public GameObject wText;
    public GameObject thText;
    public GameObject fiText;
    public GameObject topText;
    public GameObject inText;
    public GameObject ctText;
    public GameObject countText;
    public GameObject acText;
    public GameObject diText;
    public GameObject cubeText;
    public GameObject sphereText;

    private void SetActiveTest(GameObject test)
    {
        test.SetActive(true);
    }

    private void SetDisabledTest(GameObject test)
    {
        test.SetActive(false);
    }

    public void SetText(GameObject test)
    {
        SetActiveTest(test);
        StartCoroutine(TextCount(test));
    }

    IEnumerator TextCount(GameObject test)
    {
        yield return new WaitForSeconds(2f);
        SetDisabledTest(test);
    }
}
