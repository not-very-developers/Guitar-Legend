using UnityEngine;

public class RayCastWeapon : MonoBehaviour
{
    private Transform _firePoint;
    public GameObject bullet;

    private void Start()
    {
        _firePoint = GameObject.Find("PlayerFirePoint").transform;
    }

    private void Update()
    {
        if (!Input.GetButtonDown("Fire1") || !(Time.timeScale > 0.5)) return;
        Impact();
    }

    private void Impact()
    {
        Instantiate(bullet, _firePoint.position, _firePoint.rotation);
    }
    
    public void Impact(GameObject obj)
    {
        Instantiate(obj, _firePoint.position, _firePoint.rotation);
    }
}