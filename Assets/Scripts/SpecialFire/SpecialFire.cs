
using GuitarLegeng.Enemy;
using UnityEngine;

namespace GuitarLegeng.Special
{
    public abstract class SpecialFire : MonoBehaviour
    {
        [SerializeField] private GameObject impactEffect;
        [SerializeField] private float timeToDestroy = 2f;
    
        protected abstract void Setup();
        protected abstract void Impact(EnemyHealth enemy);

        private void Start()
        {
            Setup();
        }
    
        private void FixedUpdate()
        {
            Destroy(gameObject, timeToDestroy);
        }
    
        private void OnTriggerEnter2D(Collider2D hitInfo)
        { 
            if (hitInfo.CompareTag("Ground")) Die();
            if (!hitInfo.TryGetComponent(out EnemyHealth enemy)) return;
            Impact(enemy);
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
