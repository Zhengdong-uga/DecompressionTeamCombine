using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSequenceController : MonoBehaviour
{
    [Header("Main Bubble")]
    public GameObject outerBubble; // 큰 버블 (Breathing_Outer)

    [Header("Small Bubbles (Disappear in Sequence)")]
    public GameObject[] bubbles;   // 작은 버블들 (Bubble_1, Bubble_2, Breathing_3)

    [Header("Settings")]
    [Tooltip("Time in seconds between each bubble disappearing")]
    public float interval = 8f;    // <- 인스펙터에서 조절 가능

    public void StartSequence()
    {
        if (outerBubble != null)
        {
            outerBubble.SetActive(false);
        }

        StartCoroutine(DisappearBubbles());
    }

    private IEnumerator DisappearBubbles()
    {
        foreach (GameObject bubble in bubbles)
        {
            yield return new WaitForSeconds(interval);
            bubble.SetActive(false);
        }
    }
}
