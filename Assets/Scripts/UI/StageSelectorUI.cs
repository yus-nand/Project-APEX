using System;
using System.Collections.Generic;
using UnityEngine;
public class StageSelectorUI : MonoBehaviour
{
    [SerializeField] private StageDatabase stageDatabase;
    [SerializeField] private Transform buttonParent;
    [SerializeField] private StageSelectButton buttonPrefab;
    public event Action<StageData> OnStageChosen;
    private readonly List<StageSelectButton> spawnedButtons = new();
    public void Populate()
    {
        foreach(StageSelectButton button in spawnedButtons)
        {
            Destroy(button.gameObject);
        }
        spawnedButtons.Clear();

        foreach(StageData stage in stageDatabase.Stages)
        {
            StageSelectButton button = Instantiate(buttonPrefab, buttonParent);
            bool unlocked = SaveManager.Instance != null && SaveManager.Instance.IsStageUnlocked(stage, stageDatabase);
            button.Initialize(stage, unlocked, HandleStageChosen);
            spawnedButtons.Add(button);
        }
    }
    private void HandleStageChosen(StageData stageData)
    {
        OnStageChosen?.Invoke(stageData);
    }
}
