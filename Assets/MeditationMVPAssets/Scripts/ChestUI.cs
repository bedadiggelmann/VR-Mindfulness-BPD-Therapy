using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ChestUI : MonoBehaviour
{
    [Header("Start Meditation Button")]
    public GameObject StartMeditationPanel;

    [Header("Restart Buttons")]
    public GameObject RestartPanel;

    CanvasGroup canvasGroup;

    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;

        ActivateStartMeditationPanel();
    }

    public void ActivateStartMeditationPanel()
    {
        StartMeditationPanel.SetActive(true);
        RestartPanel.SetActive(false);
    }

    public void ActivateRestartPanel()
    {
        StartMeditationPanel.SetActive(false);
        RestartPanel.SetActive(true);
    }
    
    public void HideUI()
    {
        canvasGroup.DOFade(0, 0.5f);
    }

    public void ShowUI()
    {
        canvasGroup.DOFade(1, 0.5f);
    }
}
