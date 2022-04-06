using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

[RequireComponent(typeof(Rigidbody2D), typeof(Health))]
public class CharacterController2D : MonoBehaviour
{
    [SerializeField] private float m_JumpForce = 400f; // Amount of force added when the player jumps.
    public int DashImpulse = 5000;
    public KeyCode keyDash;

    [Range(0, 1)] [SerializeField]
    private float m_CrouchSpeed = .36f; // Amount of maxSpeed applied to crouching movement. 1 = 100%

    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f; // How much to smooth out the movement
    [SerializeField] private bool m_AirControl = false; // Whether or not a player can steer while jumping;
    [SerializeField] private LayerMask m_WhatIsGround; // A mask determining what is ground to the character
    [SerializeField] private Transform m_GroundCheck; // A position marking where to check if the player is grounded.
    [SerializeField] private Transform m_CeilingCheck; // A position marking where to check for ceilings
    [SerializeField] private Collider2D m_CrouchDisableCollider; // A collider that will be disabled when crouching
    [SerializeField] private float m_DashKD;
    [SerializeField] private float m_DashInvTime;

    
    const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
    private bool m_Grounded; // Whether or not the player is grounded.
    const float k_CeilingRadius = .2f; // Radius of the overlap circle to determine if the player can stand up
    private Rigidbody2D m_Rigidbody2D;
    private bool m_FacingRight = true; // For determining which way the player is currently facing.
    private Vector3 m_Velocity = Vector3.zero;
    private bool lockDash = false;
    private Health _health;
    
    [FormerlySerializedAs("OnLandEvent")] [Header("Events")] [Space]
    public UnityEvent onLandEvent;

    [System.Serializable]
    public class BoolEvent : UnityEvent<bool>
    {
    }

    [FormerlySerializedAs("OnCrouchEvent")]
    public BoolEvent onCrouchEvent;

    private bool m_wasCrouching = false;

    private void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        _health = GetComponent<Health>();
        onLandEvent ??= new UnityEvent();
        onCrouchEvent ??= new BoolEvent();
    }

    private void Update()
    {
        Dash();
    }

    private void FixedUpdate()
    {
        var wasGrounded = m_Grounded;
        m_Grounded = false;

        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        // This can be done using layers instead but Sample Assets will not overwrite your project settings.
        var colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
        foreach (var t in colliders)
        {
            if (t.gameObject == gameObject) continue;
            m_Grounded = true;
            if (!wasGrounded)
                onLandEvent.Invoke();
        }
    }


    public void Move(float move, bool crouch, bool jump)
    {
        // If crouching, check to see if the character can stand up
        if (!crouch)
        {
            // If the character has a ceiling preventing them from standing up, keep them crouching
            if (Physics2D.OverlapCircle(m_CeilingCheck.position, k_CeilingRadius, m_WhatIsGround))
            {
                crouch = true;
            }
        }

        //only control the player if grounded or airControl is turned on
        if (m_Grounded || m_AirControl)
        {
            // If crouching
            if (crouch)
            {
                if (!m_wasCrouching)
                {
                    m_wasCrouching = true;
                    onCrouchEvent.Invoke(true);
                }

                // Reduce the speed by the crouchSpeed multiplier
                move *= m_CrouchSpeed;

                // Disable one of the colliders when crouching
                if (m_CrouchDisableCollider != null)
                    m_CrouchDisableCollider.enabled = false;
            }
            else
            {
                // Enable the collider when not crouching
                if (m_CrouchDisableCollider != null)
                    m_CrouchDisableCollider.enabled = true;

                if (m_wasCrouching)
                {
                    m_wasCrouching = false;
                    onCrouchEvent.Invoke(false);
                }
            }

            // Move the character by finding the target velocity
            Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
            // And then smoothing it out and applying it to the character
            m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity,
                m_MovementSmoothing);

            // If the input is moving the player right and the player is facing left...
            if (move > 0 && !m_FacingRight)
            {
                // ... flip the player.
                Flip();
            }
            // Otherwise if the input is moving the player left and the player is facing right...
            else if (move < 0 && m_FacingRight)
            {
                // ... flip the player.
                Flip();
            }
        }

        // If the player should jump...
        if (!m_Grounded || !jump) return;

        // Add a vertical force to the player.
        m_Grounded = false;
        m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
    }


    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        transform.Rotate(0f, 180f, 0f);
    }

    private void Dash()
    {
        if (!Input.GetKey(keyDash) || lockDash) return;

        lockDash = true;
        Invoke(nameof(DashLock), m_DashKD);
        Invoke(nameof(ChangeInvis), m_DashInvTime);
        //��������� ������� ��������
        //����� �������� �� �������� �����
        m_Rigidbody2D.velocity = new Vector2(0, 0);
        if (m_FacingRight)
        {
            m_Rigidbody2D.AddForce(Vector2.right * DashImpulse);
        }
        else
        {
            m_Rigidbody2D.AddForce(Vector2.left * DashImpulse);
        }
        _health.enabled = false;
    }

    private void DashLock() => lockDash = false;

    private void ChangeInvis() => _health.enabled = true;
}