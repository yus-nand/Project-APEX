using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake Instance {get; private set;}
    [SerializeField] private CinemachineCamera cinemachineCamera;
    [Header("Shake Settings")]
    [SerializeField] private float shakeDuration = 0.15f;
    [SerializeField] private float shakeAmpltiude = 1.5f;
    private CinemachineBasicMultiChannelPerlin noise;
    private Coroutine shakeCoroutine;
    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        noise = cinemachineCamera.GetComponent<CinemachineBasicMultiChannelPerlin>();
    }
    public void Shake()
    {
        if(shakeCoroutine != null)
        {
            StopCoroutine(shakeCoroutine);
        }
        shakeCoroutine = StartCoroutine(ShakeCoroutine());
    }
    private IEnumerator ShakeCoroutine()
    {
        noise.AmplitudeGain = shakeAmpltiude;
        float elapsedTime = 0f;
        while(elapsedTime < shakeDuration)
        {
            elapsedTime += Time.deltaTime;
            noise.AmplitudeGain = Mathf.Lerp(shakeAmpltiude, 0f, elapsedTime / shakeDuration);
            yield return null;
        }
        noise.AmplitudeGain = 0f;
        shakeCoroutine = null;
    }

}
