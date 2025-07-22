using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderChecker : MonoBehaviour
{
    [SerializeField] public GameObject boulder;
    [SerializeField] public float touchTimer = 5.0f;
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
        }
    }
}
