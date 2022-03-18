using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Fire : MonoBehaviour
{
    public float timeMinKD;
    public float timeMaxKD;
    public GameObject bullet;
    private float _currKD;
    private Transform _firePoint;

    private void Start()
    {
        _firePoint = transform.GetChild(0);
        _currKD = Random.Range(timeMinKD, timeMaxKD);
    }
    public void Update()
    {
        _currKD -= Time.deltaTime;
        
        if (Time.timeScale > 0.5 && _currKD <= 0)
        {
            _currKD = Random.Range(timeMinKD, timeMaxKD);
            Instantiate(bullet, _firePoint.position, _firePoint.rotation);
        }
    }
}