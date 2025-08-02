using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltBasedOnFloor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Physics.Raycast(gameObject.transform.position,this.gameObject.transform.up*-1,out RaycastHit rayhit,0.5f);
        Vector3 floorNormal = rayhit.normal;
        Quaternion targetRotation = Quaternion.FromToRotation(Vector3.up, floorNormal);
        gameObject.transform.rotation = targetRotation;
        
    }
}
