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
    private async Task SaveAsync()
    {
        await repository.SaveAsync(currentData);
    }
}
