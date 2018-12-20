using UnityEngine;
using UnityEngine.Networking;

public class EnemySpawner : MonoBehaviour
{

    public GameObject EnemyPrefab;
    public Vector3[] spawnPositions;
    public int size;
    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < size; i++)
        {
            GameObject enemy = Instantiate(EnemyPrefab);
            enemy.transform.position = spawnPositions[i];
            NetworkServer.Spawn(enemy);
        }
    }
}