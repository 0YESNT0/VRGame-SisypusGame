using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebufBallSpawning : MonoBehaviour
{
    [SerializeField] private GameObject[] DebuffBalls;
    [SerializeField] private float SpawnInterval = 1.0f;

    public void EnableSpawning()
    {
        InvokeRepeating("SpawnBall", 0,SpawnInterval);
        Debug.LogWarning("Spawning Enabled");
    }
    public void StopSpawning()
    {
        CancelInvoke("SpawnBall");
        Debug.LogWarning("Spawning Disabled");
    }

    private void SpawnBall()
    {
        //find area to spawn based on collider
        //do spawning
        Debug.Log("Spawned Ball");
        Vector3 randomSpawnPos = new Vector3(Random.Range(-5, 5), 55, Random.Range(-18, -36));
        Instantiate(DebuffBalls[Random.Range(0, DebuffBalls.Length)], randomSpawnPos, Quaternion.identity);        
    }
}
