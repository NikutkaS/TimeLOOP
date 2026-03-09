using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 2f;
    public bool freezeRotation = true; // Флаг для заморозки вращения

    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;

        // Замораживаем вращение в Rigidbody2D
        if (freezeRotation)
        {
            rb.freezeRotation = true;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        else
        {
            rb.freezeRotation = false;
        }
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Нормализуем только если вектор не нулевой
        if (movement.sqrMagnitude > 0)
        {
            movement = movement.normalized;
        }
        // Если движения нет, оставляем movement = Vector2.zero
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}