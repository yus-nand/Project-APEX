using System;
using UnityEngine;


public class StageCompleteUI : MonoBehaviour
{
    [SerializeField] private GameObject stageCompletePanel;
    public event Action OnReturnRequested;
    private void Awake()
    {
        stageCompletePanel.SetActive(false);
    }
    public void Show(StageData stage)
    {
        Debug.Log("Stage Complete Panel on.");
        stageCompletePanel.SetActive(true);
        Time.timeScale = 0f;
        if(SaveManager.Instance != null)
            SaveManager.Instance.RecordStageComplete(stage);
    }
    public void ReturnToSelector()
    {
        stageCompletePanel.SetActive(false);
        Time.timeScale = 1f;
        OnReturnRequested?.Invoke();
    }
}
