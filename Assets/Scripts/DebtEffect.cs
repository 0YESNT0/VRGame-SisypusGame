using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DebtEffect : MonoBehaviour
{
    [SerializeField] float slowedMovement;
    [SerializeField] float normalMovement;
    [SerializeField] float slowedDuration;
    private GameObject player;
    private ContinuousMoveProviderBase movementComponent;
    void Start()
    {
        player = GameObject.Find("XR Origin (XR Rig)");
        movementComponent = player.GetComponent<ContinuousMoveProviderBase>();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Collided with player");
            StartCoroutine(SlowerMovementEffect());
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator SlowerMovementEffect()
    {
        movementComponent.moveSpeed = slowedMovement;
        yield return new WaitForSeconds(slowedDuration);
        movementComponent.moveSpeed = normalMovement;
        Destroy(gameObject);
    }
}
