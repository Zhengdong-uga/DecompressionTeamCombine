using UnityEngine;
using UnityEngine.Events;

public class StretchButtonController : MonoBehaviour
{
    public UnityEvent onButtonPressed;
    private int pressCount = 0;
    public int requiredPresses = 3;
    private bool completed = false;

    public void OnPokeTriggered()
    {
        if (completed) return;

        pressCount++;
        Debug.Log($"{gameObject.name} pressed: {pressCount}");

        if (pressCount >= requiredPresses)
        {
            completed = true;
            onButtonPressed?.Invoke();
            Debug.Log($"{gameObject.name} COMPLETED!");
        }
    }
}
