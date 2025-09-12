using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D _rb;
    [SerializeField] private float _speed = 5f;
    public InputAction playerControls;
    private bool facingRight = true;

   public Vector2 moveDir = Vector2.zero;
    
  

    private void Awake()
    {
       _rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }


    private void Update()
    {
        moveDir = playerControls.ReadValue<Vector2>();
        HandleAnimation();
        //HandleFlip();
    }

    private void HandleAnimation()
    {
        bool isWalking = _rb.linearVelocity.x != 0 || _rb.linearVelocity.y != 0;
        animator.SetBool("isWalking", isWalking);
    }

    private void FixedUpdate()
    {
        _rb.linearVelocity = new Vector2(moveDir.x * _speed, moveDir.y * _speed);
    }

    private void HandleFlip()
    {
        if (_rb.linearVelocity.x > 0 && facingRight == false)
            Flip();
        else if (_rb.linearVelocity.x < 0 && facingRight == true)
            Flip();
        
    }
    private void Flip()
    {
        transform.Rotate(0, 180, 0);
        facingRight = !facingRight;
    }
    
}
