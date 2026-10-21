using Assets.Game.Scripts.Gameplay.NPC;
using Assets.Game.Scripts.Models;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

public class NPCSpawner : MonoBehaviour
{
    [SerializeField] private int MAX_NPC_COUNT;
    [SerializeField] private NPC npcPrefab;
    [SerializeField] private GameTime maxSpawnInterval;
    [SerializeField] private GameTime minSpawnInterval;

    private Player player;

    private List<NPC> npcList = new(); 

    private GameTimeManager gameTimeManger;
    private PointStorage pointStorage;

    private GameTime lastTime;
    private GameTime timeNeedToSpawn;

    [Inject]
    public void Construct(GameTimeManager gameTimeManger, PointStorage points, Player player)
    {
        this.gameTimeManger = gameTimeManger;

        this.gameTimeManger.OnShiftStart += OnShiftStart;
        this.gameTimeManger.OnTimePast += Spawn;

        this.player = player;

        pointStorage = points;
    }

    private void OnDestroy()
    {
        if (gameTimeManger != null)
        {
            gameTimeManger.OnTimePast -= Spawn;
            gameTimeManger.OnShiftStart -= OnShiftStart;
        }
    }

    private void OnShiftStart()
    {
        lastTime = gameTimeManger.CurrentTime;
        timeNeedToSpawn = GenerateTime();
    }

    private void Spawn(GameTime currentTime)
    {
        if (npcList.Count >= MAX_NPC_COUNT) return;

        if ((currentTime - lastTime) >= timeNeedToSpawn)
        {
            SpawnNPC();
            lastTime = currentTime;
            timeNeedToSpawn = GenerateTime(); 
        }
    }

    private void SpawnNPC()
    {
        var npcObj = Instantiate(npcPrefab, pointStorage.npcSpawnPoint.position, Quaternion.identity);

        npcObj.Initialize();

        npcList.Add(npcObj);

        var npcMovement = npcObj.MovementController;
        npcMovement.SetSpeed(npcMovement.MovementSpeed * gameTimeManger.TimeMultipler);
    }

    private GameTime GenerateTime()
    {
        if (minSpawnInterval > maxSpawnInterval) 
            (minSpawnInterval, maxSpawnInterval) = (maxSpawnInterval, minSpawnInterval);

        var randomSeconds = Random.Range(minSpawnInterval.TotalSeconds, maxSpawnInterval.TotalSeconds + 1);

        return new GameTime(0, 0, randomSeconds);
    }
}
