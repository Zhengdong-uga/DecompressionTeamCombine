using UnityEngine;

public class FloatAndRotate : MonoBehaviour
{
    public float floatHeight = 0.5f;
    public float floatSpeed = 1.0f;
    public float rotationSpeed = 10.0f;

    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        // Floating
        // float newY = initialPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        // transform.position = new Vector3(initialPosition.x, newY, initialPosition.z);

        // Rotation on Y-axis
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}