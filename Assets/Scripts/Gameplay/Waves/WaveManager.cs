using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
            yield return Countdown();   
            skipRequested = false; 
            state = WaveState.Spawning;
            yield return RunWave(waveDatabase.Waves[currentWaveIndex]);
            currentWaveIndex++;
        }
        Debug.Log("All Waves Completed");
    }
    private IEnumerator Countdown()
    {
        OnCountdownVisibilityChanged?.Invoke(true);
        for(int i = 3; i > 0; i--)
        {
            OnCountdownStarted?.Invoke($"Wave starts in {i}s ...");
            yield return new WaitForSeconds(1f);    
        }
        OnCountdownStarted?.Invoke("GO!!");
        yield return new WaitForSeconds(1f);
        OnCountdownVisibilityChanged?.Invoke(false);
    }
    private IEnumerator RunWave(WaveData wave)
    {
        Queue<EnemyData> enemiesToSpawn = new Queue<EnemyData>();           
        foreach(EnemySpawnInfo spawnInfo in wave.spawnInfos)                   
        {
            for(int i = 0;i < spawnInfo.count; i++)
            {
                enemiesToSpawn.Enqueue(spawnInfo.enemyData);
            }
        }
        Debug.Log(enemiesToSpawn.Count);
        OnWaveStarted?.Invoke(currentWaveIndex + 1);
        float elapsedTimer = 0f;
        float spawnTimer = 0f;
        bool SpawningFinished = false;
        while(elapsedTimer < wave.duration)             // spawning logic
        {
            elapsedTimer += Time.deltaTime;
            spawnTimer += Time.deltaTime;
            RemainingTimer = wave.duration - elapsedTimer;
            OnRemainingTimerChanged?.Invoke(RemainingTimer);
            // Debug.Log(RemainingTimer);
            if(skipRequested)                       //skip wave? break the loop and return, starta new wave.
            {
                OnRemainingTimerChanged?.Invoke(0);
                break;
            }
            if(!SpawningFinished && spawnTimer >= wave.spawnInterval)
            {
                spawner.SpawnEnemy(enemiesToSpawn.Dequeue());       // we dequeue here. thus the COUNT property also gets modified
                spawnTimer = 0;
                if(enemiesToSpawn.Count == 0)           // no enemies left to spawn in queue.
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
