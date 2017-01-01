using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System;

public class GameScene : MonoBehaviour {
    public enum GAME_STATE{
        PLAYING,
        GAMEOVER,
        NONE,
    };
    public GAME_STATE m_GameState;
    private int m_GameScore = 0;
    public UILabel m_ScoreLabel;
    public UILabel m_TimeLabel;
    private float m_GameStartTime = 0;
    private float TOTAL_TIME = 60;

    /*Current Game Data*/
    private int m_Level;

    private static GameScene m_Instance;
    public static GameScene GetInstance() {
        return m_Instance;
    }

	void Start () {
        if (m_Instance == null) {
            m_Instance = this;
        }
        Level = 1;
        m_GameState = GAME_STATE.PLAYING;
        m_GameStartTime = Time.time;
	}
	
    void FixedUpdate() {
        if (m_GameState == GAME_STATE.PLAYING)
        {
            float pass = Time.time - m_GameStartTime;
            int left = (int)(TOTAL_TIME - pass);
            if (left <= 0) {
                left = 0;
                GameOver();
            }
            m_TimeLabel.text = string.Format("Time:{0}", left);
        }
    }

    public void GameOver() {
        m_GameState = GAME_STATE.GAMEOVER;
        OpenUI("UI/GameOver");
    }

    public int Level
    {
        set { m_Level = value; }
        get { return m_Level; }
    }

    public int Score {
        set
        {
            m_GameScore = value;
            m_ScoreLabel.text = string.Format("Score:{0}", value);
        }
        get { return m_GameScore; }
    }

    private void OpenUI(string path) {
        GameObject ui = Instantiate(Resources.Load(path)) as GameObject;
        ui.transform.parent = GameObject.Find("main").transform;
        ui.transform.localPosition = Vector3.zero;
        ui.transform.localScale = Vector3.one;
    }
}
