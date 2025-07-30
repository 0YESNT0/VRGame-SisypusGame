using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class OverTimeEffect : MonoBehaviour
{
    PostProcessVolume postProcessVolume;
    Vignette vignette;
    GameObject postProcessingManager;
    [SerializeField] float vignetteIntensity = 0f;
    [SerializeField] float durationOfVignette = 3.0f;

    void Start()
    {
        //Finds the Post Processing Manager within the scene
        postProcessingManager = GameObject.Find("PostProcessingManager");
        //Gets the Post Process Volume of the that player.
        postProcessVolume = postProcessingManager.gameObject.GetComponent<PostProcessVolume>();
        //Gets the vignette within the post process.
        postProcessVolume.profile.TryGetSettings<Vignette>(out vignette);
        if (!vignette)
        {
            Debug.Log("Vignette not found");
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
        vignette.enabled.Override(true);
        vignette.intensity.Override(vignetteIntensity);
        yield return new WaitForSeconds(durationOfVignette);
        while (vignetteIntensity > 0)
        {
            vignetteIntensity -= 0.01f;
            if (vignetteIntensity < 0)
            {
                vignetteIntensity = 0;
            }
            vignette.intensity.Override(vignetteIntensity);

            yield return new WaitForSeconds(0.1f);
        }

        vignette.enabled.Override(false);
        Destroy(gameObject);
        yield break;
        
    }
}
