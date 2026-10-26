using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

[CreateAssetMenu(menuName = "MoodData", fileName = "MoodData")]
public class MoodData : ScriptableObject
{
    public float GoodMoodValue;
    public float NeutralMoodValue;
    public float BadMoodValue;
}
