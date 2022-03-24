using UnityEngine;
using System.Collections.Generic;

public class LevelTile : MonoBehaviour
{
    public GameManager gameManager;

    public Transform tileEnd;

    public float minObstacleCount;
    public float maxObstacleCount;

    public float minCoinCount;
    public float maxCoinCount;

    public GameObject ObjectSpawnsParent;
    public List<Transform> ObjectSpawnLocations;

    void Start()
    {
        gameManager = GameManager.gameManager;

        ObjectSpawnLocations = new List<Transform>();
        for(int i = 0; i < ObjectSpawnsParent.transform.childCount; i++)
        {
            ObjectSpawnLocations.Add(ObjectSpawnsParent.transform.GetChild(i).transform);
        }
        SpawnObstacles();
        SpawnCoins();

        int random = Random.Range(0, 10);
        if(random <= 1)
        {
            int randomSpawnLocation = Random.Range(0, ObjectSpawnLocations.Count);
            GameObject coin = Instantiate(gameManager.SpecialCoinPrefab, ObjectSpawnLocations[randomSpawnLocation]);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            gameManager.TileChange();
        }
    }

    public void SpawnObstacles()
    {
        for(int i = 0; i < Random.Range(minObstacleCount, maxObstacleCount); i++)
        {
            int randomSpawnLocation = Random.Range(0, ObjectSpawnLocations.Count);
            int randomObjectPrefab = Random.Range(0, gameManager.ObjectPrefabs.Count);

            GameObject obstacle = Instantiate(gameManager.ObjectPrefabs[randomObjectPrefab], ObjectSpawnLocations[randomSpawnLocation]);

            //Need reference to obstacle prefabs 
            //Set Parent

            ObjectSpawnLocations.RemoveAt(randomSpawnLocation);
        }
    }

    public void SpawnCoins()
    {
        for (int i = 0; i < Random.Range(minCoinCount, minObstacleCount); i++)
        {
            int randomSpawnLocation = Random.Range(0, ObjectSpawnLocations.Count);

            GameObject coin = Instantiate(gameManager.CoinPrefab, ObjectSpawnLocations[randomSpawnLocation]);

            //Need reference to obstacle prefabs 
            //Set Parent

            ObjectSpawnLocations.RemoveAt(randomSpawnLocation);
        }
    }
}
