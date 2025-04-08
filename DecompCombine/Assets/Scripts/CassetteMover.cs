using UnityEngine;
using System.Collections;

public class CassetteMover : MonoBehaviour
{
    public Vector3 homePosition;
    public float moveDuration = 1.0f;
    public float forwardOffset = 0.5f;
    public float verticalOffset = -0.1f;

    private Coroutine moveCoroutine;

    void Start()
    {
        transform.localPosition = homePosition;
    }

    public void FlyOut()
    {
        if (Camera.main == null)
        {
            Debug.LogWarning("Main Camera not found, cannot fly cassette.");
            return;
        }

        Transform cameraTransform = Camera.main.transform;
        Vector3 flyToPosition = cameraTransform.position +
                                cameraTransform.forward * forwardOffset +
                                Vector3.up * verticalOffset;

        transform.SetParent(null); // 脱离父物体
        StopAllCoroutines();

        // ⚠️ 不再旋转对齐
        // transform.rotation = Quaternion.LookRotation(transform.position - cameraTransform.position);

        StartCoroutine(MoveTo(flyToPosition));
        StartCoroutine(AutoReturn());
    }

    public void ReturnHome()
    {
        if (moveCoroutine != null) StopCoroutine(moveCoroutine);
        moveCoroutine = StartCoroutine(MoveTo(homePosition));
    }

    private IEnumerator MoveTo(Vector3 targetPos)
    {
        Vector3 startPos = transform.localPosition;
        float elapsed = 0;

        while (elapsed < moveDuration)
        {
            transform.localPosition = Vector3.Lerp(startPos, targetPos, elapsed / moveDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = targetPos;
    }

    private IEnumerator AutoReturn()
    {
        yield return new WaitForSeconds(3f);
        ReturnHome();
    }
}
