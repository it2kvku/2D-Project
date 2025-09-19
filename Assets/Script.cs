using UnityEngine;
using UnityEngine.InputSystem;

public class Script : MonoBehaviour
{
    public float speed = 0.01f;
    public int direction = 1; // 1 for right, -1 for left

    private float startX;
    private float moveDistance = 10f; // 5 pixels in Unity units (1 unit = 100 pixels)

    void Start()
    {
        startX = transform.position.x;
    }

    void Update()
    {
        float move = direction * speed * Time.deltaTime;
        transform.Translate(move, 0, 0);
        float offset = transform.position.x - startX;
        if (Mathf.Abs(offset) >= moveDistance)
        {
            direction *= -1;
            // Clamp to exact bound to avoid drifting
            float clampedX = startX + Mathf.Sign(offset) * moveDistance;
            transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
        }
    }
}
