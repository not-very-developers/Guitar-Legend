using UnityEngine;

public class Enemy : MonoBehaviour {

	public int health = 100;
	public GameObject deathEffect;

	private int _hp;

	private void Awake()
	{
		_hp = health;
	}

	internal void TakeDamage (int damage)
	{
		_hp -= damage;
		if (_hp <= 0) Die();
	}

	private void Die ()
	{
		var s = Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(gameObject);
		Destroy(s);
	}
}
