using Assets.Game.Scripts.Gameplay.NPC;
using Assets.Game.Scripts.Models;
using UnityEngine;

public class NPCSpawner : MonoBehaviour
{
    [SerializeField] private GameObject phonePrefab;
    [SerializeField] private GameObject npcPrefab;
    [SerializeField] private GameTime maxSpawnInterval;
    [SerializeField] private GameTime minSpawnInterval;

    private GameTimeManager gameTimeManger;

    private Transform npcSpawnPos;

    private GameTime timeToNextClient;
    private GameTime lastTime;
    private GameTime timeNeedToSpawn;

    public void Initialize(GameTimeManager gameTimeManger, PointStorage points)
    {
        this.gameTimeManger = gameTimeManger;

        npcSpawnPos = points.enterPoint;

        lastTime = gameTimeManger.CurrentTime;

        gameTimeManger.OnTimePast += Spawn;

        timeNeedToSpawn = GenerateTime();
    }

    private void OnDestroy()
    {
        gameTimeManger.OnTimePast -= Spawn;
    }

    private void Spawn(GameTime currentTime)
    {
        if ((currentTime - lastTime) >= timeNeedToSpawn)
        {
            SpawnNPC();
            lastTime = currentTime;
            timeNeedToSpawn = GenerateTime(); 
        }
    }

    private void SpawnNPC()
    {
        var npcObj = Instantiate(npcPrefab, npcSpawnPos.position, Quaternion.identity);

        var npc = npcObj.GetComponent<NPC>();
        var clientMovement = npc.MovementController;

        clientMovement.SetSpeed(clientMovement.Speed * gameTimeManger.TimeMultipler);
    }

    private GameTime GenerateTime()
    {
        if (minSpawnInterval > maxSpawnInterval) 
            (minSpawnInterval, maxSpawnInterval) = (maxSpawnInterval, minSpawnInterval);

        var randomSeconds = Random.Range(minSpawnInterval.TotalSeconds, maxSpawnInterval.TotalSeconds);

        return new GameTime(0, 0, randomSeconds);
    }
}
