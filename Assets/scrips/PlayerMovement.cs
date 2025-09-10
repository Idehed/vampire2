using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    private float _speed = 5f;
    public InputAction playerControls;

    Vector2 moveDirection = Vector2.zero;

    private void Start()
    {
       _rb = GetComponent<Rigidbody2D>();
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
        moveDirection = playerControls.ReadValue<Vector2>();
    }
    private void FixedUpdate()
    {
        _rb.linearVelocity = new Vector2(moveDirection.x * _speed, moveDirection.y * _speed);
    }

    
}
