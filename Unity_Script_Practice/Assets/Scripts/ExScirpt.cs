using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExScirpt : MonoBehaviour
{
    public float eNum;

    public GameObject mImage;
    public GameObject[] mImages;

    public GameObject cImage;
    public GameObject[] cImages;

    public GameObject caImage;
    public GameObject[] caImages;

    public GameObject uImage;
    public GameObject[] uImages;

    public GameObject pImage;
    public GameObject[] pImages;

    public GameObject oImage;
    public GameObject[] oImages;

    private int currentMIndex;
    private int currentCIndex;
    private int currentCaIndex;
    private int currentUIndex;
    private int currentPIndex;
    private int currentOIndex;

    void Update()
    {
        if (eNum == 1)
        {
            mImage.SetActive(true);
        }
        if (eNum == 2)
        {
            cImage.SetActive(true);           
        }
        if (eNum == 3)
        {
            caImage.SetActive(true);          
        }
        if (eNum == 4)
        {
            uImage.SetActive(true);            
        }
        if (eNum == 5)
        {
            pImage.SetActive(true);         
        }
        if (eNum == 6)
        {
            oImage.SetActive(true);          
        }

        if (eNum != 1)
        {
            mImage.SetActive(false);
            currentMIndex = 0;

            for(int i = 0; i < mImages.Length; i++)
            {
                mImages[i].SetActive(false);
            }
        }
        if (eNum != 2)
        {
            cImage.SetActive(false);
            currentCIndex = 0;

            for (int i = 0; i < cImages.Length; i++)
            {
                cImages[i].SetActive(false);
            }
        }
        if (eNum != 3)
        {
            caImage.SetActive(false);
            currentCaIndex = 0;

            for (int i = 0; i < caImages.Length; i++)
            {
                caImages[i].SetActive(false);
            }
        }
        if (eNum != 4)
        {
            uImage.SetActive(false);
            currentUIndex = 0;

            for (int i = 0; i < uImages.Length; i++)
            {
                uImages[i].SetActive(false);
            }
        }
        if (eNum != 5)
        {
            pImage.SetActive(false);
            currentPIndex = 0;

            for (int i = 0; i < pImages.Length; i++)
            {
                pImages[i].SetActive(false);
            }
        }
        if (eNum != 6)
        {
            oImage.SetActive(false);
            currentOIndex = 0;

            for (int i = 0; i < oImages.Length; i++)
            {
                oImages[i].SetActive(false);
            }
        }
    }

    public void NextImage()
    {
        if (eNum == 1)
        {
            mImages[currentMIndex].SetActive(false);

            currentMIndex = (currentMIndex + 1) % mImages.Length;

            mImages[currentMIndex].SetActive(true);
        }
        if (eNum == 2)
        {
            cImages[currentCIndex].SetActive(false);

            currentCIndex = (currentCIndex + 1) % cImages.Length;

            cImages[currentCIndex].SetActive(true);
        }
        if (eNum == 3)
        {
            caImages[currentCaIndex].SetActive(false);

            currentCaIndex = (currentCaIndex + 1) % caImages.Length;

            caImages[currentCaIndex].SetActive(true);
        }
        if (eNum == 4)
        {
            uImages[currentUIndex].SetActive(false);

            currentUIndex = (currentUIndex + 1) % uImages.Length;

            uImages[currentUIndex].SetActive(true);
        }
        if (eNum == 5)
        {
            pImages[currentPIndex].SetActive(false);

            currentPIndex = (currentPIndex + 1) % pImages.Length;

            pImages[currentPIndex].SetActive(true);
        }
        if (eNum == 6)
        {
            oImages[currentOIndex].SetActive(false);

            currentOIndex = (currentOIndex + 1) % oImages.Length;

            oImages[currentOIndex].SetActive(true);
        }
    }
}
