using UnityEngine;
using UnityEngine.UI;

public class StartNextWaveButton : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private WaveManager waveManager;
    private void Awake()
    {
        button.gameObject.SetActive(false);
    }
    public void StartNextWave()
    {
        button.gameObject.SetActive(false);
        waveManager.SkipCurrentWave();
    }
    public void Show()
    {
        button.gameObject.SetActive(true);
    }
}
