 using System;
using System.Collections;
using UnityEngine;

public class GameTimeManager : MonoBehaviour
{
    [SerializeField] private float timeMultipler = 1;
    [SerializeField] private int shiftStart = 9;
    [SerializeField] private int shiftEnd = 20;
    [SerializeField] private int shiftTimeInReal = 10;
    public int CurrentHours => currentHours;
    public int CurrentMinutes => currentMinutes;
    public event Action<int, int> OnTimePast;
    public event Action OnShiftStart;
    public event Action OnShiftEnd;
    private int currentHours;
    private int currentMinutes;
    private float currentSeconds;
    private float timeSpeed;
    private int overallTime;
    private bool isShiftActive = false;

    public void Initialzie()
    {
        overallTime = shiftEnd - shiftStart;

        var overallTimeInSeconds = overallTime * 3600;

        var realTimeInSeconds = shiftTimeInReal * 60;

        timeSpeed = overallTimeInSeconds / realTimeInSeconds;
    }

    public void StartShift()
    {
        currentHours = shiftStart;
        currentMinutes = 0;
        currentSeconds = 0;

        isShiftActive = true;

        OnShiftStart?.Invoke();
        OnTimePast?.Invoke(currentHours, currentMinutes);
    }


    private void Update()
    {
        if (!isShiftActive) return;

        currentSeconds += timeSpeed * Time.deltaTime * timeMultipler;

        if (currentSeconds >= 60f)
        {
            int minutesToEarn = (int)(currentSeconds / 60f);
            currentSeconds %= 60f;

            currentMinutes += minutesToEarn;

            if (currentMinutes >= 60)
            {
                int hoursToEarn = currentMinutes / 60;
                currentMinutes %= 60;
                currentHours += hoursToEarn;
            }

            if (currentHours >= shiftEnd)
            {
                currentHours = shiftEnd;
                currentMinutes = 0;
                isShiftActive = false;

                OnTimePast?.Invoke(currentHours, currentMinutes);
                OnShiftEnd?.Invoke();
            }
            else
            {
                OnTimePast?.Invoke(currentHours, currentMinutes);
            }
        }
    }
}
