using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MissionButton : MonoBehaviour
{
    public GameObject buttonObj;
    public Button button;

    public GameObject managerTextobj;
    public TMP_Text managerText;

    public GameObject countDownTextObj;
    public TMP_Text countDownText;

    public Mission mission;

    public bool performingMission;

    public void Setup(Mission mission) 
    {
        performingMission = false;
        managerText.text = mission.managerName;
        this.mission = mission;
        ResetMissionButton();

    }

    public void SetMissionTime(int timeLeftInSecond)
    {
        TimeSpan missionDuration = new(0, 0, (int)timeLeftInSecond);
        countDownText.text = missionDuration.ToString("c");
    }

    public void ResetMissionButton()
    {
        TimeSpan missionDuration = new(0, 0, (int)mission.missionDurationInSecond);
        countDownText.text = missionDuration.ToString("c");
    }
}
