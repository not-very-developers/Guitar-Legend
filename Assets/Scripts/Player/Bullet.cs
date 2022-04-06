using System;
using GuitarLegeng.Enemy;
using UnityEngine;

namespace GuitarLegeng.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float speed = 20f;
        [SerializeField] private int damage = 40;
        [SerializeField] private GameObject impactEffect;
        private Rigidbody2D _rb;

        // Use this for initialization
        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            var player = GameObject.Find("Player");
            if (Math.Abs(player.transform.rotation.y + 1) < 0.000001)
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
            if (!hitInfo.TryGetComponent(out EnemyHealth enemy)) return;
            enemy.TakeDamage(damage);
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
}