using UnityEngine;
using TMPro;
using System;
public class WaveUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI remainingTimerText;
    [SerializeField] private TextMeshProUGUI waveCountdownText;
    [SerializeField] private TextMeshProUGUI waveNumberText;
    [SerializeField] private WaveManager waveManager;

    private void OnEnable()
    {
        waveManager.OnRemainingTimerChanged += UpdateRemainingTimerText;
        waveManager.OnWaveStarted += UpdateWaveNumberText;
        waveManager.OnCountdownStarted += UpdateWaveCountDown;
        waveManager.OnCountdownVisibilityChanged += UpdateCountdownVisibility;
    }
    private void OnDisable()
    {
        waveManager.OnRemainingTimerChanged -= UpdateRemainingTimerText;
        waveManager.OnWaveStarted -= UpdateWaveNumberText;
        waveManager.OnCountdownStarted -= UpdateWaveCountDown;
        waveManager.OnCountdownVisibilityChanged -= UpdateCountdownVisibility;
    }
    private void UpdateRemainingTimerText(float time)
    {
        TimeSpan t = TimeSpan.FromSeconds(time);
        remainingTimerText.text = $"{t.Minutes:00}:{t.Seconds:00}s";
    }
    private void UpdateWaveNumberText(int waveNumber)
    {
        waveNumberText.text = $"Wave: {waveNumber}";
    }
    private void UpdateWaveCountDown(string message)
    {
        waveCountdownText.text = message;
    }
    private void UpdateCountdownVisibility(bool visibility)
    {
        waveCountdownText.gameObject.SetActive(visibility);
    }
}
