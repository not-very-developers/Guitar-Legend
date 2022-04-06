using System;
using GuitarLegeng.Enemy;
using UnityEngine;

namespace GuitarLegeng.Special
{
    public class TestFire : SpecialFire
    {
        [SerializeField] private float speed = 10f;
        [SerializeField] private int damage = 100;
        private Rigidbody2D _rb;
        protected override void Setup()
        {
            _rb = GetComponent<Rigidbody2D>();
            var player = GameObject.Find("Player");
            if (Math.Abs(player.transform.rotation.y + 1) < 0.000001)
                _rb.velocity = Vector2.left * speed;
            else
                _rb.velocity = Vector2.right * speed;
        }
    
        protected override void Impact(EnemyHealth enemy)
        {
            enemy.TakeDamage(damage);
        }
    }
}
