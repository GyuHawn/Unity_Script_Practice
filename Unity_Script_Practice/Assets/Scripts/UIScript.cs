using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIScript : MonoBehaviour
{
    // 현재 사용한 버튼
    public float uNum;

    // 현재 시간 관련 변수
    public GameObject currentTime;
    public TMP_Text currentTimeText;

    // 글 입력 관련 변수
    public GameObject textInput;
    public TMP_InputField chatInput;
    public TMP_Text viewChat;

    // 카운드 다운 관련 변수
    public GameObject countDown;
    public TMP_Text countDowntext;
    private Button plus;
    private Button minus;
    private Button countStart;
    private TimeSpan countdownTime = TimeSpan.Zero;
    private bool countdownStarted = false;

    void Start()
    {
        UpdateCountdownText();
        chatInput.onEndEdit.AddListener(SubmitChat);
    }


    void Update()
    {
        currentTimeText.text = DateTime.Now.ToString("HH : mm : ss");

        if (countdownStarted && countdownTime > TimeSpan.Zero)
        {
            countdownTime -= TimeSpan.FromSeconds(Time.deltaTime);
            UpdateCountdownText();
        }
    }

    public void TextInptBt()
    {
        textInput.SetActive(!textInput.activeSelf);
    }
    public void CurrentTimeBt()
    {
        currentTime.SetActive(!currentTime.activeSelf);
    }
    public void CountDownBt()
    {
        countDown.SetActive(!countDown.activeSelf);
    }



    public void PulseMinute()
    {
        countdownTime += TimeSpan.FromMinutes(1);
        UpdateCountdownText();
    }

    public void MinusMinute()
    {
        if (countdownTime.Minutes > 0)
        {
            countdownTime -= TimeSpan.FromMinutes(1);
            UpdateCountdownText();
        }
    }

    public void StartCountdown()
    {
        if (!countdownStarted && countdownTime > TimeSpan.Zero)
        {
            countdownStarted = true;
        }
    }

    void UpdateCountdownText()
    {
        countDowntext.text = string.Format("{0:D2}:{1:D2}", countdownTime.Minutes, countdownTime.Seconds);
    }


    public void SubmitChat(string chatMessage)
    {
        viewChat.text = chatMessage;
        chatInput.text = "";
        chatInput.ActivateInputField();

        StartCoroutine(ClearViewChatAfterDelay(1f));
    }

    IEnumerator ClearViewChatAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        viewChat.text = "";
    }
}