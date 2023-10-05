using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotalScript : MonoBehaviour
{
    private MoveScript mScript;

    // 현재 사용한 버튼
    public float pNum;

    // 포탈 관련 변수
    public GameObject bPotal;
    public GameObject wPotal;

    public GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        mScript = GameObject.Find("Player").GetComponent<MoveScript>();
    }

    void Update()
    {
        if (pNum == 1)
        {
            bPotal.SetActive(true);
        }
        else if (pNum == 2)
        {
            bPotal.SetActive(false);

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!mScript.moveMap)
            {
                player.transform.position = new Vector3(3, 1.5f, 160);
                mScript.moveMap = true;
            }
            else
            {
                player.transform.position = new Vector3(-40, 1, 5);
                mScript.moveMap = false;
            }
        }
    }
}
