using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SlideInPopUp : MonoBehaviour
{
    [SerializeField] private float FadeOutdelay = 1.0f;
    [SerializeField] private AnimationCurve Curve;
    public UnityEvent OnEventEnable = new UnityEvent();


    private void OnEnable()
    {

    }

    private void DoExitOut()
    {
        this.gameObject.SetActive(false);
        
    }
}
