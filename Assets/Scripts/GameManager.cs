using System.Collections;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public MissionContainer missionContainer;

    public GameObject missionButtonPrefab;

    public GameObject gamePanel;

    public TMP_Text playerMoneyText;

    public PlayerData playerData;

    void Start()
    {
        GenerateMissionButton();
    }

    void GenerateMissionButton()
    {
        foreach(Mission mission in missionContainer.missions)
        {
            GameObject newButton = Instantiate(missionButtonPrefab);
            MissionButton missionButton = newButton.GetComponent<MissionButton>();

            missionButton.Setup(mission);

            newButton.transform.SetParent(gamePanel.transform, false);

            missionButton.button.onClick.AddListener(delegate { PerformMission(missionButton); });
        }

    }

    void PerformMission(MissionButton missionButton)
    {
        if(missionButton.mission.inProgress)
        {
            return;
        }
        StartCoroutine(WaitForMission(missionButton));
    }

    IEnumerator WaitForMission(MissionButton missionButton)
    {
        missionButton.mission.inProgress = true;
        float currentTimer = missionButton.mission.missionDurationInSecond;
        while(currentTimer > 0)
        { 
            yield return new WaitForSeconds(1);
            currentTimer--;
            missionButton.SetMissionTime((int) currentTimer);
        }
        playerData.playerMoney += missionButton.mission.moneyReward;
        missionButton.ResetMissionButton();
        playerMoneyText.text = playerData.playerMoney.ToString();
    }

    void Update()
    {
        
    }
}
