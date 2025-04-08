using UnityEngine;

public class StretchSessionManager : MonoBehaviour
{
    public Animator trainerAnimator;
    public AudioSource saluteAudio;

    private int buttonsCompleted = 0;
    private int totalButtons = 4;

    public void RegisterButtonCompletion()
    {
        buttonsCompleted++;
        Debug.Log($"Button completed: {buttonsCompleted}/{totalButtons}");

        if (buttonsCompleted >= totalButtons)
        {
            trainerAnimator.SetTrigger("PlaySalute");

            if (saluteAudio != null)
                saluteAudio.Play();

            Debug.Log("🎉 SALUTE TRIGGERED: SOUND ONLY!");
        }
    }
}

