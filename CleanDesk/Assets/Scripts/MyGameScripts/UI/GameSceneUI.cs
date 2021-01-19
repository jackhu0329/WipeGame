using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameFrame;
public class GameSceneUI : MonoBehaviour
{
    private  float clock = 30;
    private int mode = 1;
    private int score = 0;
    private float timer;
    private bool timerBool = true, UI = true;
    public Text time;
    public Text scoreText;
    public GameObject Result;
    private bool gameStart = false;
    private int StainCount = 0;
    private bool hasCorrection = true;
    
    void Awake()
    {
        timer = 0;
        //transform.GetComponent<Canvas>().transform.GetChild(0).gameObject.SetActive(false);
        GameEventCenter.AddEvent("GetScore", GetScore);
        GameEventCenter.AddEvent("Add", Add);
        GameEventCenter.AddEvent("Del", Del);
        GameEventCenter.AddEvent("CorrectionUI", CorrectionUI);

        //GameEventCenter.AddEvent<int>("BookNumber", BookNumber);
        TimerStart();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("UI start");
        //test

        //test
        if(mode == 1&& hasCorrection)
        {
            if (clock > 0)
            {
                clock -= Time.deltaTime;
                time.text = "" + Mathf.FloorToInt(clock);
            }else
            {
                Result.SetActive(true);
                clock = 0;
                time.text = "" + Mathf.FloorToInt(clock);
                scoreText.text = "任務完成數: " + score;
                GameEventCenter.DispatchEvent<AudioSelect>("PlayAudio", AudioSelect.EndAudio);
            }
            
            
            if (StainCount > 0)
            {
                gameStart = true;
            }else if(StainCount ==0&& gameStart)
            {
                GameEventCenter.DispatchEvent("SpawnLevel1");
            }
        }



        if (timerBool)
        {
            timer += Time.deltaTime;
        }

    }

    private void OnGUI()
    {
        GUIStyle gameUI = new GUIStyle();
        gameUI.normal.textColor = new Color(255, 255, 255);
        gameUI.fontSize = 60;

        if (UI&& hasCorrection)
        {
            GUI.Label(new Rect(Screen.width / 10 * 1, (Screen.height / 6 * 5), 200, 100),
            "已完成" + score + "次"
            , gameUI);

        }else{
            GUI.Label(new Rect(Screen.width / 10 * 4, (Screen.height / 6 * 1), 200, 100),
            "請伸直手臂並按住扳機鍵進行校正"
            , gameUI);
        }

    }

    private void CorrectionUI()
    {
        hasCorrection = true;
    }

    private void Add()
    {
        StainCount++;
    }

    private void Del()
    {
        StainCount--;
    }

    public void GetScore()
    {
        score++;
    }

    private void TimerStart()
    {
        timerBool = true;
    }

    private void TimerEnd()
    {
        if (timerBool)
        {
            timerBool = false;
        }

    }




}
