using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    public float timestart = 60;
    public Text tx;
    void Start()
    {
        tx.text = timestart.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        timestart -= Time.deltaTime;
        tx.text = timestart.ToString();
    }
}