using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class SpecialTreatment : MonoBehaviour
{
    public GameObject pausePanel;
    public float repeatTime;
    public float kdTime;
    public float curr_time;
    private bool checkKey = false;
    public KeyCode r;

    void Awake()
    {
        pausePanel.SetActive(false);
    }
    void SetSpecialTreatment()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0.00001f;
    }
    void SpecialTreatmentOff()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(r) && !checkKey)
        {
            
            SetSpecialTreatment();
            curr_time = repeatTime + kdTime;
            checkKey = true;
        }
        if (checkKey)
        {
            curr_time -= (Time.deltaTime* 10000); /* Вычитаем из repeatTime время кадра (оно в миллисекундах) */
            if (curr_time <= kdTime) /* Время вышло пишем */
            {
                SpecialTreatmentOff();
                if(curr_time <= 0)
                {
                    checkKey = false;
                } 
            }
        }
    }
}
