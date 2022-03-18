using UnityEngine;

public class RayCastWeapon : MonoBehaviour
{
    private Transform _firePoint;
    public GameObject bullet;

    private void Start()
    {
        _firePoint = transform.GetChild(2);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.timeScale > 0.5)
        {
            Instantiate(bullet, _firePoint.position, _firePoint.rotation);
        }
    }
}