using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyBullet : MonoBehaviour
{
    public float speed = 20f;
    public GameObject impactEffect;
    private Rigidbody2D _rb;

    // Use this for initialization
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        var player = GameObject.Find("Player").transform;
        var s = transform.position.x - player.position.x;
        if (s > 0)
            _rb.velocity = Vector2.left * speed;
        else
            _rb.velocity = Vector2.right * speed;
    }
    
    private void FixedUpdate()
    {
        Destroy(gameObject, 2.0f);
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    { 
        if (hitInfo.CompareTag("Ground")) Die();
        if (!hitInfo.TryGetComponent(out Health enemy)) return;
        if (!enemy.enabled) return;
        enemy.TakeDamage();
        Die();
    }

    private void Die()
    {
        var transform1 = transform;
        var s = Instantiate(impactEffect, transform1.position, transform1.rotation);
        Destroy(gameObject);
        Destroy(s, 1.0f);
    }
}