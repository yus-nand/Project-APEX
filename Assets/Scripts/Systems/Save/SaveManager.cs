using System.Threading.Tasks;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance{ get; private set; }
    private ISaveRepository repository;
    private SaveData currentData;
    public SaveData CurrentData => currentData;
    private async void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        repository = new JsonFileSaveRepository();
        currentData = await repository.LoadAsync();
        Debug.Log($"Best wave reached: {currentData.statistics.bestWaveReached}");
        Debug.Log($"Total runs: {currentData.statistics.totalRunsPlayed}");
    }
    public void RecordRunEnd(int waveReached)
    {
        currentData.statistics.totalRunsPlayed++;
        if(waveReached > currentData.statistics.bestWaveReached)
            currentData.statistics.bestWaveReached = waveReached;

        _ = SaveAsync();
    }
    public void RecordStageComplete(StageData stageData)
    {
        currentData.coins += stageData.currencyReward;
        currentData.statistics.totalRunsPlayed ++;

        if(stageData.nextStage != null && !currentData.unlocks.Contains(stageData.nextStage.id))
            currentData.unlocks.Add(stageData.nextStage.id);

        _ = SaveAsync();
    }
    public bool IsStageUnlocked(StageData stage, StageDatabase stageDatabase)
    {
        if(stageDatabase.Stages.Count > 0 && stageDatabase.Stages[0] == stage)
            return true;

        return currentData.unlocks.Contains(stage.id);
    }
    private async Task SaveAsync()
    {
        await repository.SaveAsync(currentData);
    }
}
