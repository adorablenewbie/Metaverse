using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public static Vector3 playerPosition
    {
        get; set;
    }

    Vector3 startPosition = playerPosition;

    [SerializeField] private float interactRange = 2f;
    [SerializeField] private LayerMask interactable;
    private IInteractable currentTarget;

    private InputControl inputActions;
    private Vector2 moveInput;
    public float moveSpeed = 5f;
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    private void Awake()
    {
        inputActions = new InputControl();

        // 액션 연결
        inputActions.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        inputActions.Player.Move.canceled += ctx => moveInput = Vector2.zero;
        inputActions.Player.Interaction.performed += _ => TryInteract();

        transform.position = startPosition;
        playerPosition = new Vector3(0, 0, 0);

    }
    private void OnEnable()
    {
        inputActions.Enable();
    }
    private void OnDisable()
    {
        inputActions.Disable();
    }

    void Update()
    {
        Vector3 move = new Vector3(moveInput.x, moveInput.y, 0);
        transform.position += move * moveSpeed * Time.deltaTime;

        PlayerControls();
        CheckForInteractables();
    }

    void PlayerControls()
    {
        if (moveInput != Vector2.zero)
        {
            animator.SetBool("isMove", true);
        }
        else
        {
            animator.SetBool("isMove", false);
        }

        if (moveInput.x > 0)
        {
            animator.SetBool("isSide", true);
            animator.SetBool("isUp", false);
            animator.SetBool("isDown", false);
            spriteRenderer.flipX = false;
        }
        else if (moveInput.x < 0)
        {
            animator.SetBool("isSide", true);
            animator.SetBool("isUp", false);
            animator.SetBool("isDown", false);
            spriteRenderer.flipX = true;
        }

        if (moveInput.y > 0)
        {
            animator.SetBool("isUp", true);
            animator.SetBool("isDown", false);
            animator.SetBool("isSide", false);
        }
        else if (moveInput.y < 0)
        {
            animator.SetBool("isUp", false);
            animator.SetBool("isDown", true);
            animator.SetBool("isSide", false);
        }
    }
    private void CheckForInteractables()
    {
        currentTarget = null;

        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, interactRange, interactable);
        foreach (var hit in hits)
        {
            var interactable = hit.GetComponent<IInteractable>();
            if (interactable != null)
            {
                currentTarget = interactable;
                // UI 등에 interactable.GetInteractPrompt() 로 안내 출력 가능
                break;
            }
        }
    }

    private void TryInteract()
    {
        currentTarget?.Interact();
    }

}
