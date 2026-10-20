using Assets.Game.Scripts.Models;
using System;
using System.Collections;
using UnityEngine;

public class GameTimeManager : MonoBehaviour
{
    public static GameTimeManager Instance { get; private set; }
    [SerializeField] private float timeMultipler = 1;
    [SerializeField] private GameTime shiftStart;
    [SerializeField] private GameTime shiftEnd;
    [SerializeField] private GameTime shiftTimeInReal;

    public GameTime CurrentTime => currentTime;
    public float TimeMultipler => timeMultipler;
    public float DeltaTimeSeconds => isShiftActive ? timeSpeed * Time.deltaTime * timeMultipler : 0f;

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
        Instance = this;

        var endSecondsTime = shiftEnd.TotalSeconds;

        var realTimeSeconds = shiftTimeInReal.TotalSeconds;

        timeSpeed = endSecondsTime / realTimeSeconds;
    }

    public void StartShift()
    {
        currentTime = shiftStart;
        totalGameSeconds = currentTime.TotalSeconds;

        isShiftActive = true;

        OnShiftStart?.Invoke();
        OnTimePast?.Invoke(currentTime);
    }


    private void Update()
    {
        if (!isShiftActive) return;

        totalGameSeconds += DeltaTimeSeconds;

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
