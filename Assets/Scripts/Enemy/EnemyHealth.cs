using UnityEngine;

namespace GuitarLegeng.Enemy
{
	public class EnemyHealth : MonoBehaviour {

		[SerializeField] private int health = 100;
		[SerializeField] private GameObject deathEffect;

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

		private void Die()
		{
			var s = Instantiate(deathEffect, transform.position, Quaternion.identity);
			Destroy(gameObject);
			Destroy(s, 1.0f);
		}
	}

}