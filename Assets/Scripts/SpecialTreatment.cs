using UnityEngine;

public class SpecialTreatment : MonoBehaviour
{
    public GameObject pausePanel;
    public float repeatTime;
    public float kdTime;
    public float curr_time;
    private bool checkKey = false;
    public KeyCode r;

    private void Awake()
    {
        pausePanel.SetActive(false);
    }

    private void SetSpecialTreatment()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0.00001f;
    }

    private void SpecialTreatmentOff()
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
            curr_time -= (Time.deltaTime* 10000); /* �������� �� repeatTime ����� ����� (��� � �������������) */
            if (curr_time <= kdTime) /* ����� ����� ����� */
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
