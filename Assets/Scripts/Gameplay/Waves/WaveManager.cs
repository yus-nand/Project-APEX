using System.Collections;
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
    public float RemainingTimer {get; private set;}
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
        Debug.Log($"Wave {waveNumber} begins in: ");
        for(int i = 3; i > 0; i--)
        {
            Debug.Log(i);
            yield return new WaitForSeconds(1f);
        }
        Debug.Log("GO!");
    }
    private IEnumerator RunWave(WaveData wave)
    {
        float elapsedTimer = 0f;
        float spawnTimer = 0f;
        bool SpawningFinished = false;
        int enemiesSpawned = 0;
        while(elapsedTimer < wave.duration)
        {
            elapsedTimer += Time.deltaTime;
            spawnTimer += Time.deltaTime;
            RemainingTimer = wave.duration - elapsedTimer;
            Debug.Log(RemainingTimer);
            if(skipRequested)
            {
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
