using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DebtEffect : MonoBehaviour
{
   
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            DebuffManager.Instance.StartSlowedDebuff();
        }
        Destroy(gameObject);
    }
}
