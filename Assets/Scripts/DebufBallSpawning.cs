using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebufBallSpawning : MonoBehaviour
{
    [SerializeField] private GameObject DebuffBalls;
    [SerializeField] private float SpawnInterval = 1.0f;

    public void EnableSpawning()
    {
        Invoke("SpawnBall", SpawnInterval);
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
    }
}
