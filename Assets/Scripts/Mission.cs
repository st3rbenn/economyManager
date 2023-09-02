using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Mission", menuName = "Manager/Mission", order = 1)]
public class Mission : ScriptableObject
{
    public string managerName;
    public float missionDurationInSecond;
    public long moneyReward;

    public bool inProgress;
}
