using Assets.Game.Scripts.Models;
using System;
using System.Collections;
using UnityEngine;

public class GameTimeManager : MonoBehaviour
{
    [SerializeField] private float timeMultipler = 1;
    [SerializeField] private GameTime shiftStart;
    [SerializeField] private GameTime shiftEnd;
    [SerializeField] private GameTime shiftTimeInReal;
    public GameTime CurrentTime => currentTime;
    public float TimeMultipler => timeMultipler;

    public event Action<GameTime> OnTimePast;
    public event Action OnShiftStart;
    public event Action OnShiftEnd;

    private GameTime currentTime;

    private float timeSpeed;
    private float totalGameSeconds;
    private int lastMinute = -1;

    private bool isShiftActive = false;

    public void Initialzie()
    {
        var endSecondsTime = shiftEnd.TotalSeconds;

        var realTimeSeconds = shiftTimeInReal.TotalSeconds;

        timeSpeed = endSecondsTime / realTimeSeconds;
    }

    public void StartShift()
    {
        currentTime = shiftStart;

        isShiftActive = true;

        OnShiftStart?.Invoke();
        OnTimePast?.Invoke(currentTime);
    }


    private void Update()
    {
        if (!isShiftActive) return;

        totalGameSeconds += timeSpeed * Time.deltaTime * timeMultipler;

        currentTime = new GameTime(0,0, (int)totalGameSeconds);

        if (currentTime.Minutes != lastMinute)
        {
            lastMinute = currentTime.Minutes;
            OnTimePast?.Invoke(currentTime);
        }

        if (currentTime >= shiftEnd)
        {
            currentTime = shiftEnd;

            isShiftActive = false;

            OnTimePast?.Invoke(currentTime);
            OnShiftEnd?.Invoke();
        }
    }
}
