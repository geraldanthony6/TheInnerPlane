using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Scriptable Objects/RockData")]
public class RockSO : ScriptableObject
{
    public MineralTypes MineralType;

    public float MaxPurityLevel;

    public float MineralMultiplier;
}
