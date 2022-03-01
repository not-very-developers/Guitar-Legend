using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerControl : MonoBehaviour
{
    public float horizontalSpeed = 10.0f;
    public float jumpH = 200.0f;
    
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
        var movement = new Vector2(moveHorizontal * horizontalSpeed, _rigidbody.velocity.y);
        _rigidbody.velocity = movement;
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