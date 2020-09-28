using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    int counter = 10;
    int score = 0;
    bool timerBool = false,timerUI = false;
    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("timer", 1, 1);
        GameEventCenter.AddEvent("timerStart", timerStart);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            timerBool = true;
        }


        if (timerBool)
        {
            InvokeRepeating("timer", 1, 1);
            timerBool = false;
            
        }
        else
        {
            if (counter == 0)
            {
                CancelInvoke("timer");
                counter = 10;
                timerBool = false;
                timerUI = false;
                score++;
            }
            /*CancelInvoke("timer");
            counter = 10;*/
            //timerBool = false;
        }
    }

    void OnGUI()
    {

        GUIStyle gameUI = new GUIStyle();
        gameUI.normal.textColor = new Color(255, 255, 255);
        gameUI.fontSize = 30;

        GUI.Label(new Rect(Screen.width / 10 * 7, (Screen.height / 8 * 1), 200, 100),
        "已完成" + score + "次"
        , gameUI);


        if (timerUI && counter >= 0)
        {
            //counter -= Time.deltaTime;
            GUI.Label(new Rect(Screen.width / 10 * 3, (Screen.height / 8 * 1), 200, 100),
""+Mathf.FloorToInt(counter)
, gameUI);
        }
    }

    void timer()
    {
        counter--;
    }

    void timerStart()
    {
        timerBool = true;
        timerUI = true;
    }
}
