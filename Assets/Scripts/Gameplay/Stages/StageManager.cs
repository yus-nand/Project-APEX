using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField] private WaveManager waveManager;
    [SerializeField] private StageCompleteUI stageCompleteUI;

    private StageData currentStage;
    private void Awake()
    {
        waveManager.OnAllWavesCompleted += HandleAllWavesCompleted;
    }
    public void BeginStage(StageData stageData)
    {
        currentStage = stageData;
        waveManager.Initialize(stageData.waveDatabase);
    }
    private void OnDestroy()
    {
        Debug.Log($"Destroying {name}");
        if(waveManager != null)
            waveManager.OnAllWavesCompleted -= HandleAllWavesCompleted;
    }
    private void HandleAllWavesCompleted()
    {
        Debug.Log("Showing StageComplete UI panel");
        stageCompleteUI.Show(currentStage);
    }
}
