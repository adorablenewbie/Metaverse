using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Interactor"))
        {

        }
    }   
}
