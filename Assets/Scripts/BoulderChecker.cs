using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderChecker : MonoBehaviour
{
    [SerializeField] public GameObject boulder;
    [SerializeField] public float touchTimer = 5.0f;
    [SerializeField] public GameObject door;
    [SerializeField] private Transform doorWaypoint;
    [SerializeField] private float doorMoveSpeed = 5.0f;
    private Collider boulderCollider;
    public void Touchcheck()
    {
        boulderCollider = boulder.GetComponent<SphereCollider>();
        if (boulderCollider.CompareTag("PlayerHands"))
        {
            touchTimer = 5.0f;
            Debug.Log("Player Still Touching ball");
        }
        else
        {
            //Touch timer counts down and if done 
            //door moves up and player wins
            Debug.Log("No Player is touching.");
            if (touchTimer <= 0)
            {
                door.transform.position = Vector3.MoveTowards(door.transform.position, doorWaypoint.position, doorMoveSpeed);
                Rigidbody rb = boulder.GetComponent<Rigidbody>();
                rb.isKinematic = true;
            }
        }
    }

    void Update()
    {
        touchTimer -= Time.deltaTime;
    }
}
