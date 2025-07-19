using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderAndPlayerRespawn : MonoBehaviour
{
    [SerializeField] public GameObject player;
    [SerializeField] public GameObject boulder;
    [SerializeField] private GameObject playerSpawn;
    [SerializeField] private GameObject boulderSpawn;
     public void RespawnBoulder()
    {
        Debug.Log("Ball Respawn");
        boulder.transform.position = boulderSpawn.transform.position;
    }

    public void RespawnPlayer()
    {
        Debug.Log("Player Respawn");
        player.transform.position = playerSpawn.transform.position;
    }
}
