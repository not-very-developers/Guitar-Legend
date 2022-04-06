
using UnityEngine;

public abstract class SpecialFire : MonoBehaviour
{
    [SerializeField] public GameObject impactEffect;
    [SerializeField] public float timeToDestroy = 2f;
    
    public abstract void Setup();
    public abstract void Impact(EnemyHealth enemy);

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