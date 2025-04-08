using UnityEngine;
using System.Collections;

public class BlockBehavior : MonoBehaviour
{
    public static BlockBehavior selectedBlock;
    public Vector3 moveTarget;
    public float moveSpeed = 0.1f; // Slower movement

    private bool isMoving = false;

    void Update()
    {
        if (isMoving)
        {
            transform.position = Vector3.Lerp(transform.position, moveTarget, Time.deltaTime * moveSpeed);
        }
    }

    public void OnSelected()
    {
        if (selectedBlock != null) return;

        selectedBlock = this;

        BlockBehavior[] allBlocks = FindObjectsOfType<BlockBehavior>();
        foreach (var block in allBlocks)
        {
            if (block != this)
            {
                block.StartCoroutine(block.FadeAfterDelay(0f)); // fade after 1 sec
            }
        }

        StartCoroutine(StartMoveAfterDelay(4f)); // move after 2 sec
    }

    IEnumerator StartMoveAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        isMoving = true;
    }

    public IEnumerator FadeAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        float duration = 1f;
        float elapsed = 0f;

        Renderer rend = GetComponent<Renderer>();
        Material mat = rend.material;
        Color originalColor = mat.color;

        // Ensure fade mode
        mat.SetFloat("_Mode", 2); // Fade
        mat.EnableKeyword("_ALPHABLEND_ON");
        mat.renderQueue = 3000;

        while (elapsed < duration)
        {
            float alpha = Mathf.Lerp(1f, 0f, elapsed / duration);
            mat.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            elapsed += Time.deltaTime;
            yield return null;
        }

        gameObject.SetActive(false);
    }
}


