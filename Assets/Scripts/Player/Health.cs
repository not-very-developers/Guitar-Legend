﻿using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int maxHp = 3;
    private int _currHp;

    private void Start()
    {
        _currHp = maxHp;
    }

    internal void TakeDamage()
    {
        _currHp--;
        if (_currHp <= 0) Die();
    }

    private void Die()
    {
        var s = GetComponent<PlayerMovement>();
        s.enabled = false;
        Destroy(gameObject, 1.0f);
    }

    private void OnDestroy()
    {
        SceneManager.LoadScene("Main");
    }
}