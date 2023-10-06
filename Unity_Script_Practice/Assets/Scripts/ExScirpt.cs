using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExScirpt : MonoBehaviour
{
    public GameObject mImage;
    public GameObject[] mImages;

    public GameObject cImage;
    public GameObject[] cImags;

    public GameObject caImage;
    public GameObject[] caImages;

    public GameObject uImage;
    public GameObject[] uImages;

    public GameObject pImage;
    public GameObject[] pImags;

    public GameObject oImage;
    public GameObject[] oImages;

    public Button nextEX;

    private int currentMIndex = 0;

    void Start()
    {
        for (int i = 1; i < mImages.Length; i++)
        {
            mImages[i].SetActive(false);
        }
    }

    public void NextMImage()
    {
        mImages[currentMIndex].SetActive(false);

        currentMIndex = (currentMIndex + 1) % mImages.Length;

        mImages[currentMIndex].SetActive(true);
    }
}
// 사용할 배열 조건 (지금은 어떤 배열을 사용 중이다)
// 사용 중인 배열에 따라 정상 작동