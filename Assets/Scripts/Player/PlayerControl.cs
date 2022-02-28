using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerControl : MonoBehaviour
{
    public float horizontalSpeed = 10.0f;
    public float jumpH = 1.0f;
    
    private bool _isGrounded = true;
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        MovementLogic();
        JumpLogic();
    }

    private void MovementLogic()
    {
        var moveHorizontal = Input.GetAxis("Horizontal");
        var movement = new Vector3(moveHorizontal, 0.0f, 0.0f);
        if (Math.Abs(_rigidbody.velocity.magnitude - 0.00001f) > 35.00000f) return;
        _rigidbody.AddForce(movement * horizontalSpeed);
    }

    private void JumpLogic()
    {
        if (!_isGrounded) return;
        if (Input.GetAxis("Jump") < 0.001f) return;
        _rigidbody.AddForce(new Vector2(0.0f, jumpH));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IsGroundedUpdate(collision, true);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        IsGroundedUpdate(collision, false);
    }

    private void IsGroundedUpdate(Collision2D collision, bool value)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = value;
        }
    }
}