using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.XR.Interaction.Toolkit;

public class VignetteDebuff : MonoBehaviour
{
    GameObject tunnelingVignette;
    TunnelingVignetteController tunnelingVignetteController;
    XROrigin xrOrigin;
    [SerializeField] float vignetteIntensity = 0f;
    [SerializeField] float durationOfVignette = 3.0f;

    void Start()
    {
        //xrOrigin = GameObject.Find("XR Origin (XR Rig)");
        tunnelingVignette = GameObject.Find("TunnelingVignette");
        tunnelingVignetteController = tunnelingVignette.GetComponent <TunnelingVignetteController>();
        if (tunnelingVignetteController == null)
        {
            Debug.LogError("Tunneling Vignette not found");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Collided with player");
            StartCoroutine(VignetteEffect());
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator VignetteEffect()
    {
        tunnelingVignetteController.defaultParameters.apertureSize = 0.2f;
        
    }
}
