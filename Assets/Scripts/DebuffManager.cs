using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
[System.Serializable]
public class DebuffManager:MonoBehaviour
{
    [SerializeField]private GameObject playerObj;
    [SerializeField] private float reverseDuration = 5;
    [SerializeField] private float slowedDuration = 5;
    private float baseMoveSpeed;
    private ContinuousMoveProviderBase movementProviderScr;
    public static DebuffManager Instance{get;private set;}
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
    void Start(){
        movementProviderScr = playerObj.GetComponent<ContinuousMoveProviderBase>();
        baseMoveSpeed = movementProviderScr.moveSpeed;
    }

    public IEnumerator ReverseMovementIEnum()
    {        
        movementProviderScr.moveSpeed *= -1;
        yield return new WaitForSeconds(reverseDuration);
        movementProviderScr.moveSpeed = baseMoveSpeed;
    }

    public IEnumerator SlowedMovementIEnum(){
        movementProviderScr.moveSpeed /= 2;
        yield return new WaitForSeconds(slowedDuration);
        movementProviderScr.moveSpeed = baseMoveSpeed;
    }

    public void StartReverseDebuff(){
        StopCoroutine(ReverseMovementIEnum());
        StartCoroutine(ReverseMovementIEnum());
        
    }

    public void StartSlowedDebuff(){
        StopCoroutine(SlowedMovementIEnum());
        StartCoroutine(SlowedMovementIEnum());
       
    }
}
