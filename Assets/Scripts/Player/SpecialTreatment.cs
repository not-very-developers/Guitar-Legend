using GuitarLegeng.Special;
using UnityEngine;
using UnityEngine.UI;

namespace GuitarLegeng.Player
{
    [RequireComponent(typeof(RayCastWeapon))]
public class SpecialTreatment : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private float repeatTime;
    [SerializeField] private float kdTime;
    [SerializeField] private KeyCode keySpecial;

    private float curr_time;
    private bool checkKey = false;
    private float curr_kd;

    private Scrollbar _progressBar;
    private InputField _inputField;
    private RayCastWeapon _weapon;
    private SpecialList _list;
    
    [SerializeField] private float min = 80f;
    [SerializeField] private float max = 320f;

    private void Awake()
    {
        pausePanel.SetActive(false);
        curr_kd = 0f;
        _progressBar = pausePanel.transform.GetChild(0).GetChild(2).gameObject
            .GetComponent<Scrollbar>();
        _inputField = pausePanel.transform.GetChild(0).GetChild(0).GetComponent<InputField>();
        _weapon = GameObject.Find("Player").GetComponent<RayCastWeapon>();
        _list = GameObject.Find("Player").GetComponent<SpecialList>();
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

        if (Input.GetKey(KeyCode.Space))
        {
            var text = _inputField.text.Remove(_inputField.text.Length-1);
            if (_list.TryGet(text, out var specialFire))
                _weapon.Impact(specialFire);
            SpecialTreatmentOff();
            return;
        }
        curr_time -= Time.unscaledDeltaTime;
        _progressBar.size = curr_time / repeatTime;
        
        if (!(curr_time <= 0)) return;

        SpecialTreatmentOff();
        checkKey = false;
    }

    private void SetSpecialTreatment()
    {
        pausePanel.SetActive(true);
        _inputField.ActivateInputField();
        _inputField.text = "";
        Time.timeScale = 0;
    }

    private void SpecialTreatmentOff()
    {
        pausePanel.SetActive(false);
        _inputField.DeactivateInputField();
        Time.timeScale = 1;
        curr_kd = kdTime;
    }
}
}
