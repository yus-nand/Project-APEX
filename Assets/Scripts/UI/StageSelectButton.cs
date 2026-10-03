using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
public class StageSelectButton : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private TMP_Text label;
    [SerializeField] private GameObject lockedOverlay;
    public void Initialize(StageData stage, bool unlocked, Action<StageData> onChosen)
    {
        label.text = stage.stageName;
        button.interactable = unlocked;
        if(lockedOverlay != null)
            lockedOverlay.SetActive(!unlocked);

        button.onClick.AddListener(() => onChosen?.Invoke(stage));
    }
}
