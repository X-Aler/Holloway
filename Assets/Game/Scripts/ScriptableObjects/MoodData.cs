using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

[CreateAssetMenu(menuName = "MoodData", fileName = "MoodData")]
public class MoodData : ScriptableObject
{
    [SerializeField] private Sprite goodSmile;
    [SerializeField] private Sprite neutralSmile;
    [SerializeField] private Sprite badSmile;

    [Range(0, 1)][SerializeField] private float goodMoodValue;
    [Range(0, 1)][SerializeField] private float neutralMoodValue;
    [Range(0, 1)][SerializeField] private float badMoodValue;

    public float GoodMoodValue => goodMoodValue;
    public float NeutralMoodValue => neutralMoodValue;
    public float BadMoodValue => badMoodValue;

    public Sprite GetSmile(MoodType mood) => mood switch
    { 
        MoodType.Good => goodSmile,
        MoodType.Neutral => neutralSmile,
        MoodType.Bad => badSmile,
        _ => null
    };
}
