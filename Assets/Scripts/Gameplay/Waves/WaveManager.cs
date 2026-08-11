using System;
using System.Collections;
using TMPro;
using UnityEngine;

public enum WaveState
{
    Countdown,
    Spawning,
    Cleanup,
}
public class WaveManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private WaveDatabase waveDatabase;
    [SerializeField] private EnemySpawner spawner;
    [SerializeField] private StartNextWaveButton button;
    public event Action<float> OnRemainingTimerChanged;
    public event Action<int> OnWaveStarted;
    public event Action<string> OnCountdownStarted;
    public event Action<bool> OnCountdownVisibilityChanged;
    // public event Action<int> OnWaveEnded;

    public float RemainingTimer {get; private set;}
    public float CurrentWave => currentWaveIndex + 1;
    public WaveState CurrentState => state;
    private int currentWaveIndex;
    private bool skipRequested = false;
    private WaveState state;

    private void Start()
    {
        StartCoroutine(WaveLoop());
        state = WaveState.Countdown;
    }
    private IEnumerator WaveLoop()
    {
        while(currentWaveIndex < waveDatabase.Waves.Count)
        {
            yield return Countdown(currentWaveIndex + 1);   
            skipRequested = false; 
            state = WaveState.Spawning;
            yield return RunWave(waveDatabase.Waves[currentWaveIndex]);
            currentWaveIndex++;
        }
        Debug.Log("All Waves Completed");
    }
    private IEnumerator Countdown(int waveNumber)
    {
        // waveCountdownText.gameObject.SetActive(true);
        // waveNumberText.text = $"Wave: {waveNumber}";
        OnCountdownVisibilityChanged?.Invoke(true);
        for(int i = 3; i > 0; i--)
        {
            OnCountdownStarted?.Invoke($"Wave starts in {i}s ...");
            yield return new WaitForSeconds(1f);    
        }
        OnCountdownStarted?.Invoke("GO!!");
        yield return new WaitForSeconds(1f);
        OnCountdownVisibilityChanged?.Invoke(false);
        // waveCountdownText.gameObject.SetActive(false);

    }
    private IEnumerator RunWave(WaveData wave)
    {
        OnWaveStarted?.Invoke(currentWaveIndex + 1);
        float elapsedTimer = 0f;
        float spawnTimer = 0f;
        bool SpawningFinished = false;
        int enemiesSpawned = 0;
        while(elapsedTimer < wave.duration)
        {
            elapsedTimer += Time.deltaTime;
            spawnTimer += Time.deltaTime;
            RemainingTimer = wave.duration - elapsedTimer;
            OnRemainingTimerChanged?.Invoke(RemainingTimer);
            Debug.Log(RemainingTimer);
            if(skipRequested)
            {
                OnRemainingTimerChanged?.Invoke(0);
                break;
            }
            if(!SpawningFinished && spawnTimer >= wave.spawnInterval)
            {
                spawner.SpawnEnemy();
                enemiesSpawned++;
                spawnTimer = 0;
                if(enemiesSpawned >= wave.enemyCount)
                {
                    Debug.Log("Spawning Complete");
                    SpawningFinished = true;                    
                    state = WaveState.Cleanup;
                    button.Show();
                }
            }
            yield return null;
        }
    }
    public void SkipCurrentWave()
    {
        skipRequested = true;
    }
}
