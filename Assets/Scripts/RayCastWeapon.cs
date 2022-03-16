using System;
using System.Collections;
using UnityEngine;

public class RayCastWeapon : MonoBehaviour
{
    private Transform _firePoint;
    public int damage = 40;
    public GameObject impactEffect;
    public LineRenderer lineRenderer;

    private void Start()
    {
        _firePoint = GameObject.Find("FirePoint").transform;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(Shoot());
        }
    }

    private IEnumerator Shoot()
    {
        var hitInfo = Physics2D.Raycast(_firePoint.position, Vector2.right);
        if (hitInfo)
        {
            var enemy = hitInfo.transform.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            var s = Instantiate(impactEffect, hitInfo.point, Quaternion.identity);
            lineRenderer.SetPosition(0, _firePoint.position);
            lineRenderer.SetPosition(1, hitInfo.point);
            Destroy(s);
        }
        else
        {
            lineRenderer.SetPosition(0, _firePoint.position);
            lineRenderer.SetPosition(1, _firePoint.position + _firePoint.right * 100);
        }

        lineRenderer.enabled = true;

        yield return 0;

        lineRenderer.enabled = false;
    }
}