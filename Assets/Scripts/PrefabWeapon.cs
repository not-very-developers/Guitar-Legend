using UnityEngine;

public class PrefabWeapon : MonoBehaviour {

	public Transform firePoint;
	public GameObject bulletPrefab;
	
	// Update is called once per frame
	private void Update () {
		if (Input.GetButtonDown("Fire1"))
		{
			Shoot();
		}
	}

	private void Shoot ()
	{
		var s = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
		Destroy(s);
	}
}
