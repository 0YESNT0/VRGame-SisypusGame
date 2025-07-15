using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class OnAreaEnterScript : MonoBehaviour
{
    [SerializeField] private string DetectTag;
    public UnityEvent OnColliderEnter = new UnityEvent();
    public UnityEvent OnColliderExit = new UnityEvent();

    private void OnTriggerEnter(Collider collider){
        if(collider.gameObject.CompareTag(DetectTag) == true)OnColliderEnter?.Invoke();
    }
    private void OnTriggerExit(Collider collider){
        if(collider.gameObject.CompareTag(DetectTag) == true) OnColliderExit?.Invoke();
    }

}
