using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    public float timestart = 60;
    public Text tx;

    private void Start()
    {
        tx.text = timestart.ToString("F");
    }

    // Update is called once per frame
    private void Update()
    {
        timestart -= Time.deltaTime;
        tx.text = timestart.ToString("F");
    }
}