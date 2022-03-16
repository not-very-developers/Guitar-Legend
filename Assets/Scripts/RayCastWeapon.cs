using UnityEngine;

public class RayCastWeapon : MonoBehaviour
{
    private Transform _firePoint;
    public GameObject bullet;

    private void Start()
    {
        _firePoint = GameObject.Find("FirePoint").transform;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(bullet, _firePoint.position, _firePoint.rotation);
        }
    }
}