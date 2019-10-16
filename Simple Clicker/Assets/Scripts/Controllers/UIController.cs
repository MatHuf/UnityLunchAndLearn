using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] Text scoreText = default;
    [SerializeField] CanvasGroup upgradesButtonCanvasGroup = default;
    [SerializeField] CanvasGroup upgradesPanelCanvasGroup = default;
    bool upgradesPanelShown = false;

    #region Public
    public void UpdateScore(int newScore)
    {
        scoreText.text = newScore.ToString();
    }

    public void ToggleUpgradesPanel()
    {
        if (upgradesPanelShown)
        {
            HideCanvasGroup(upgradesPanelCanvasGroup);
            ShowCanvasGroup(upgradesButtonCanvasGroup);
        }
        else
        {
            HideCanvasGroup(upgradesButtonCanvasGroup);
            ShowCanvasGroup(upgradesPanelCanvasGroup);
        }
        upgradesPanelShown = !upgradesPanelShown;
    }
    #endregion

    #region  Private
    // Hiding/showing a canvas group this way results in less draw calls
    // than enabling/disabling the GameObject or moving it out of camera view
    void HideCanvasGroup(CanvasGroup group)
    {
        group.alpha = 0;
        group.interactable = false;
        group.blocksRaycasts = false;
    }

    void ShowCanvasGroup(CanvasGroup group)
    {
        group.alpha = 1;
        group.interactable = true;
        group.blocksRaycasts = true;
    }
    #endregion
}
