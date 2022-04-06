using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GuitarLegeng.Enemy
{
    public class Fire : MonoBehaviour
    {
        [SerializeField] private float timeMinKD;
        [SerializeField] private float timeMaxKD;
        [SerializeField] private GameObject bullet;
        private float _currKD;
        private Transform _firePoint;

        private void Start()
        {
            _firePoint = transform.GetChild(0);
            _currKD = Random.Range(timeMinKD, timeMaxKD);
        }
        private void Update()
        {
            _currKD -= Time.deltaTime;

            if (!(Time.timeScale > 0.5) || !(_currKD <= 0)) return;
            
            _currKD = Random.Range(timeMinKD, timeMaxKD);
            Instantiate(bullet, _firePoint.position, _firePoint.rotation);
        }
    }
}