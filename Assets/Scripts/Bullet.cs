using UnityEngine;

public class Bullet : MonoBehaviour {
	public float speed = 20f;
	public int damage = 40;
	private Rigidbody2D _rb;
	public GameObject impactEffect;

	// Use this for initialization
	private void Start ()
	{
		_rb = GetComponent<Rigidbody2D>();
		_rb.velocity = Vector2.right * speed;
	}

	private void OnTriggerEnter2D (Collider2D hitInfo)
	{
		var enemy = hitInfo.GetComponent<Enemy>();
		if (enemy != null)
		{
			enemy.TakeDamage(damage);
		}
		var transform1 = transform;
		var s = Instantiate(impactEffect, transform1.position, transform1.rotation);
		Destroy(gameObject);
		Destroy(s);
	}
	
}
