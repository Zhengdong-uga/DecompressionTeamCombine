using UnityEngine;

public class StepSwitcher : MonoBehaviour
{
    public GameObject[] steps;  // 所有步骤的 group
    private int currentStep = 0;

    void Start()
    {
        // 初始化只显示当前步骤，其他隐藏
        for (int i = 0; i < steps.Length; i++)
        {
            steps[i].SetActive(i == currentStep);
        }
    }

    public void SwitchToNextStep()
    {
        Debug.Log("切换步骤！当前是 Step " + currentStep);

        if (currentStep < steps.Length - 1)
        {
            steps[currentStep].SetActive(false);
            currentStep++;
            steps[currentStep].SetActive(true);
        }
        else
        {
            Debug.Log("已经是最后一个步骤了");
        }
    }
}
