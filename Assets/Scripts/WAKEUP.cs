using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WAKEUP : MonoBehaviour
{
    void Update()
    {
        if (gameObject.GetComponent<Rigidbody>().IsSleeping())
        {
            gameObject.GetComponent<Rigidbody>().WakeUp();
        }
    }
}
