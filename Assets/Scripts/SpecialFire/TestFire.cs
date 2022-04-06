using System;
using UnityEngine;

public class TestFire : SpecialFire
{
    public float speed = 10f;
    public int damage = 100;
    private Rigidbody2D _rb;
    public override void Setup()
    {
        _rb = GetComponent<Rigidbody2D>();
        var player = GameObject.Find("Player");
        if (Math.Abs(player.transform.rotation.y + 1) < 0.000001)
            _rb.velocity = Vector2.left * speed;
        else
            _rb.velocity = Vector2.right * speed;
    }

    public override void Impact(EnemyHealth enemy)
    {
        enemy.TakeDamage(damage);
    }
}