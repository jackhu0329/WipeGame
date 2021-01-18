using System.Collections;
using System.Collections.Generic;
using GameData;
using LabData;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
    public Button startButton;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            GameSceneManager.Instance.Change2MainScene();
        }
    }

    private void Start()
    {
        Debug.Log("Game Start");
        startButton.onClick.AddListener(StartButton);
        GameSceneManager.Instance.Change2MainScene();
        // GameSceneManager.Instance.Change2MainScene();
    }

    private void StartButton()
    {
        GameSceneManager.Instance.Change2MainScene();
    }
}
