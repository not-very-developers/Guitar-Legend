using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    public float timeStart = 60;
    private float _curTime;
    public Text tx;

    private void Start()
    {
        _curTime = timeStart;
        Debug.Log(_curTime.ToString("F"));
    }

    // Update is called once per frame
    private void Update()
    {
        _curTime -= Time.unscaledDeltaTime;
        Debug.Log(_curTime.ToString("F"));
    }
}