using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator animator;
    private Vector2 lastMoveDirection;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Vector2 move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        bool isMoving = move.sqrMagnitude > 0.01f;

        animator.SetBool("IsMoving", isMoving);

        if (isMoving)
        {
            // ќбновл€ем последнее направление движени€
            lastMoveDirection = move.normalized;

            // ѕередаем текущее направление в аниматор
            animator.SetFloat("Horizontal", move.x);
            animator.SetFloat("Vertical", move.y);
        }
        else
        {
            //  огда персонаж стоит, передаем последнее направление движени€
            animator.SetFloat("Horizontal", lastMoveDirection.x);
            animator.SetFloat("Vertical", lastMoveDirection.y);
        }
    }
}