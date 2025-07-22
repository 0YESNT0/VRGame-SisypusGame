using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderAndPlayerRespawn : MonoBehaviour
{
    [SerializeField] public GameObject player;
    [SerializeField] public GameObject boulder;
    [SerializeField] private Transform playerSpawn;
    [SerializeField] private Transform boulderSpawn;
     public void RespawnBoulder()
    {
        Debug.Log("Ball Respawn");
        boulder.transform.position = boulderSpawn.transform.position;
    }

    public void RespawnPlayer()
    {
        Debug.Log("Player Respawn");
        player.GetComponent<CharacterController>().enabled = false;
        player.transform.position = playerSpawn.transform.position;
        player.GetComponent<CharacterController>().enabled = true;
    }
}
