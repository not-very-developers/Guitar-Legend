using UnityEngine;
using UnityEngine.UI;

public class SpecialTreatment : MonoBehaviour
{
    public GameObject pausePanel;
    public float repeatTime;
    public float kdTime;
    public KeyCode keySpecial;

    private float curr_time;
    private bool checkKey = false;
    private float curr_kd;

    private Scrollbar progresBar;

    public float min = 80f;
    public float max = 320f;

    private void Awake()
    {
        pausePanel.SetActive(false);
        curr_kd = 0f;
        progresBar = pausePanel.transform.GetChild(0).GetChild(2).gameObject
            .GetComponent<Scrollbar>();
    }

    private void Update()
    {
        if (curr_kd > 0)
        {
            curr_kd -= Time.deltaTime;
            return;
        }

        if (Input.GetKey(keySpecial) && !checkKey)
        {
            SetSpecialTreatment();
            curr_time = repeatTime;
            checkKey = true;
        }

        if (!checkKey) return;

        curr_time -= Time.unscaledDeltaTime;
        progresBar.size = curr_time / repeatTime;
        
        if (!(curr_time <= 0)) return;

        SpecialTreatmentOff();
        checkKey = false;
    }

    private void SetSpecialTreatment()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    private void SpecialTreatmentOff()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
        curr_kd = kdTime;
    }
}