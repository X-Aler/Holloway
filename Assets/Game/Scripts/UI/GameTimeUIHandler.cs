using TMPro;
using UnityEngine;

public class GameTimeUIHandler : MonoBehaviour
{
    [SerializeField] private TMP_Text timeText;
    public void Initialzie(GameTimeManager manager)
    {
        manager.OnTimePast += UpdateTimeUI;
    }

    private void UpdateTimeUI(int currentHours, int currentMinutes)
    {
        var timeAbbreviation = currentHours >= 12 ? "PM" : "AM";

        timeText.text = $"{currentHours}:{currentMinutes:D2} {timeAbbreviation}";
    }
}
