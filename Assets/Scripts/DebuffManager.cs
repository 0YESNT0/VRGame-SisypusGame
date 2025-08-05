using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
[System.Serializable]
public class DebuffManager : MonoBehaviour
{
    [SerializeField] private GameObject playerObj;
    [SerializeField] private float reverseDuration = 5;
    [SerializeField] private float slowedDuration = 5;
    [SerializeField] float vignetteIntensity = 0.8f;
    [SerializeField] float durationOfVignette = 3.0f;
    private float baseMoveSpeed;
    private ContinuousMoveProviderBase movementProviderScr;
    private GameObject tunnelingVignette;
    private TunnelingVignetteController tunnelingVignetteController;
    public static DebuffManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // Prevent duplicate instances
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); // Persist across scenes
    }
    void Start()
    {
        movementProviderScr = playerObj.GetComponent<ContinuousMoveProviderBase>();
        tunnelingVignette = GameObject.Find("TunnelingVignette");
        tunnelingVignetteController = tunnelingVignette.GetComponent<TunnelingVignetteController>();
        baseMoveSpeed = movementProviderScr.moveSpeed;
    }

    public IEnumerator ReverseMovementIEnum()
    {
        movementProviderScr.moveSpeed *= -1;
        yield return new WaitForSeconds(reverseDuration);
        movementProviderScr.moveSpeed = baseMoveSpeed;
    }

    public IEnumerator SlowedMovementIEnum()
    {
        movementProviderScr.moveSpeed /= 2;
        yield return new WaitForSeconds(slowedDuration);
        movementProviderScr.moveSpeed = baseMoveSpeed;
    }

    public IEnumerator VignetteIEnum()
    {
        tunnelingVignetteController.defaultParameters.apertureSize = vignetteIntensity;
        tunnelingVignetteController.defaultParameters.easeOutDelayTime = durationOfVignette;
        yield return new WaitForSeconds(reverseDuration);
        tunnelingVignetteController.defaultParameters.apertureSize = 1f;
        tunnelingVignetteController.defaultParameters.easeOutDelayTime = 0f;
    }

    public void StartReverseDebuff()
    {
        StopCoroutine(ReverseMovementIEnum());
        StartCoroutine(ReverseMovementIEnum());

    }

    public void StartSlowedDebuff()
    {
        StopCoroutine(SlowedMovementIEnum());
        StartCoroutine(SlowedMovementIEnum());

    }

    public void StartVignetteDebuff()
    {
        StopCoroutine(VignetteIEnum());
        StartCoroutine(VignetteIEnum());
    }
}
