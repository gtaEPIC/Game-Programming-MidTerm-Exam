using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Animator _anim;
    private SpriteRenderer _spriteRenderer;
    private bool _isGrounded;
    private bool _isDucking;
    
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 15f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        
        if (!groundCheck) throw new Exception("Ground check object not set");
    }

    private void Update()
    {
        _isGrounded = IsGrounded();
        _anim.SetBool("isGrounded", _isGrounded);
        float horizontal = Input.GetAxis("Horizontal") * speed;
        _rb.velocity = new Vector2(horizontal, _rb.velocity.y);
        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, jumpForce);
            _isGrounded = false;
        }
        _isDucking = Input.GetButton("Duck");
        _anim.SetBool("isDucking", _isDucking);
        _anim.SetFloat("xSpeed", Math.Abs(_rb.velocity.x));
        Face(_rb.velocity.x >= 0);
        _anim.SetFloat("ySpeed", _rb.velocity.y);
    }
    
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.5f, groundLayer);
    }

    private void Face(bool right)
    {
        _spriteRenderer.flipX = !right;
    }
}
