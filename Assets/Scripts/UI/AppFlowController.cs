using System.Collections;
using UnityEngine;

public class AppFlowController : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject titlePanel;
    [SerializeField] private GameObject loadingPanel;
    [SerializeField] private GameObject gameUI;
    [SerializeField] private StageSelectorUI stageSelectorUI;
    [SerializeField] private StageCompleteUI stageCompleteUI;

    [Header("Referneces")]
    [SerializeField] private StageManager stageManager;
    [Header("Settings")]
    [SerializeField] private float loadingDuration = 1.5f;

    private StageData pendingStage;

    private void Awake()
    {
        stageSelectorUI.OnStageChosen += HandleStageChosen;
        stageCompleteUI.OnReturnRequested += ShowSelector;
    }
    private void OnDestroy()
    {
        stageSelectorUI.OnStageChosen -= HandleStageChosen;
        stageCompleteUI.OnReturnRequested -= ShowSelector;
    }
    private void Start()
    {
        ShowTitle();
    }
    public void ShowTitle()
    {
        titlePanel.SetActive(true);
        gameUI.SetActive(false);
        loadingPanel.SetActive(false);
        stageSelectorUI.gameObject.SetActive(false);
    }
    public void ShowSelector()
    {
        titlePanel.SetActive(false);
        loadingPanel.SetActive(false);
        gameUI.SetActive(false);
        stageSelectorUI.gameObject.SetActive(true);
        stageSelectorUI.Populate();
    }
    private void HandleStageChosen(StageData stageData)
    {
        pendingStage = stageData;
        stageSelectorUI.gameObject.SetActive(false);
        loadingPanel.SetActive(true);
        StartCoroutine(LoadStageRoutine());
    }
    private IEnumerator LoadStageRoutine()
    {
        yield return new WaitForSeconds(loadingDuration);
        loadingPanel.SetActive(false);
        gameUI.SetActive(true);
        stageManager.BeginStage(pendingStage);
    }
}
