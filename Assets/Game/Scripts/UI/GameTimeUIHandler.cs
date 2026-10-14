using Assets.Game.Scripts.Models;
using TMPro;
using UnityEngine;

public class GameTimeUIHandler : MonoBehaviour
{
    [SerializeField] private TMP_Text timeText;
    public void Initialzie(GameTimeManager manager)
    {
        manager.OnTimePast += UpdateTimeUI;
    }

    private void UpdateTimeUI(GameTime currentTime)
    {
        var timeAbbreviation = currentTime.Hours >= 12 ? "PM" : "AM";

        timeText.text = $"{currentTime.Hours}:{currentTime.Minutes:D2} {timeAbbreviation}";
    }
}
