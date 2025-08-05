using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class ResetGame : MonoBehaviour
{
    [SerializeField] public GameObject player;
    [SerializeField] public GameObject boulder;
    [SerializeField] private Transform playerSpawn;
    [SerializeField] private Transform boulderSpawn;
    [SerializeField] private Transform doorOrigPosition;
    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        player.GetComponent<CharacterController>().enabled = false;
        player.transform.position = playerSpawn.transform.position;
        player.GetComponent<CharacterController>().enabled = true;
        boulder.transform.position = boulderSpawn.transform.position;
        boulder.transform.localScale *= 1.25f;
        StopCoroutine(DoorMoveDown());
        StartCoroutine(DoorMoveDown());
    }

    private IEnumerator DoorMoveDown()
    {
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, doorOrigPosition.transform.position, 5.0f);
        Rigidbody rb = boulder.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        yield return new WaitForSeconds(1);
    }
}
