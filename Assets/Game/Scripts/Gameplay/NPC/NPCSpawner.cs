using Assets.Game.Scripts.Models;
using Assets.Game.Scripts.Systems.Controllers;
using Assets.Game.Scripts.Systems.Managers;
using Assets.Game.Scripts.UI.MenuButtons;
using UnityEngine;

public class NPCSpawner : MonoBehaviour
{
    [SerializeField] private GameObject phonePrefab;
    [SerializeField] private GameObject npcPrefab;
    [SerializeField] private GameTime maxSpawnInterval;
    [SerializeField] private GameTime minSpawnInterval;

    private GameTimeManager gameTimeManger;
    private ClientsManager clientsManager;

    private Transform npcSpawnPos;

    private GameTime timeToNextClient;
    private GameTime lastTime;
    private GameTime timeNeedToSpawn;

    public void Initialize(GameTimeManager gameTimeManger, ClientsManager clientsManager, PointStorage points)
    {
        this.gameTimeManger = gameTimeManger;
        this.clientsManager = clientsManager;

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
        var npc = Instantiate(npcPrefab, npcSpawnPos.position, Quaternion.identity);

        var client = npc.GetComponent<Client>();
        var clientMovement = npc.GetComponent<MovementController>();
        clientMovement.SetSpeed(clientMovement.Speed * gameTimeManger.TimeMultipler);

        client.Initialize(phonePrefab);

        clientsManager.AddClient(client);
    }

    private GameTime GenerateTime()
    {
        if (minSpawnInterval > maxSpawnInterval) 
            (minSpawnInterval, maxSpawnInterval) = (maxSpawnInterval, minSpawnInterval);

        var randomSeconds = Random.Range(minSpawnInterval.TotalSeconds, maxSpawnInterval.TotalSeconds);

        return new GameTime(0, 0, randomSeconds);
    }
}
