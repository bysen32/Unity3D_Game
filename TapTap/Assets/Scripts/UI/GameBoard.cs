using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System;

public class GameBoard : MonoBehaviour {
    public UILabel m_ScoreLabel;
    public UILabel m_TimeLabel;

    public void SetLeftTime(float leftTime) {
        leftTime = Mathf.Clamp(leftTime, 0, leftTime);
        m_TimeLabel.text = "Time:" + leftTime.ToString("00");
    }

    public void SetScore(float score) {
        m_ScoreLabel.text = "Score:" + score.ToString("00");
    }
}
