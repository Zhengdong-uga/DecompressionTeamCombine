using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThumbFeedbackHandler : MonoBehaviour
{
    public GameObject questionPanel;
    public GameObject nextStage;
    public float delaySeconds = 1.5f;

    public void OnThumbSelected()
    {
        Invoke(nameof(SwitchToNextStage), delaySeconds);
    }

    private void SwitchToNextStage()
    {
        questionPanel.SetActive(false);
        nextStage.SetActive(true);
    }
}
