using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    [SerializeField] float RotationSpeed = 25.0f;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,RotationSpeed*Time.deltaTime,0);
    }
}
