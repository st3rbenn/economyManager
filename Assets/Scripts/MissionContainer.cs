using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MissionContainer", menuName = "Manager/MissionContainer", order = 1)]
public class MissionContainer : ScriptableObject
{
    public Mission[] missions;
}
